using System.Text;
using System.Xml;
using Maple2.File.IO.Crypto.Common;

namespace Maple2.File.IO {
    /// <summary>
    /// An <see cref="M2dReader"/> that reads plain files from a directory tree instead of a packed
    /// <c>.m2d</c>/<c>.m2h</c> archive. It lets the same parsers (FlatTypeIndex, AssetIndex, MapParser,
    /// NpcParser, TableParser) consume an already-extracted dump (e.g. LithMS2-XML) with no <c>.m2d</c> present.
    ///
    /// Each file under <paramref name="baseDir"/> becomes a <see cref="PackFileEntry"/> whose <c>Name</c> is the
    /// forward-slashed path relative to <paramref name="baseDir"/> — matching the archive-internal paths the
    /// parsers filter on (<c>entry.Name.StartsWith("flat")</c>, <c>EndsWith(".nt")</c>, <c>StartsWith("map/")</c>,
    /// and the suffix match in <see cref="M2dReader.GetEntry"/> for e.g. <c>en/mapname.xml</c>). The
    /// file-reading methods are overridden to read straight from disk; the inherited <c>GetEntry</c> and
    /// <c>Files</c> already work off the list built here.
    /// </summary>
    public class LooseM2dReader : M2dReader {
        private readonly string baseDir;

        public LooseM2dReader(string baseDir) : base() {
            this.baseDir = baseDir;
            var list = new List<PackFileEntry>();
            if (Directory.Exists(baseDir)) {
                int index = 0;
                foreach (string full in Directory.EnumerateFiles(baseDir, "*", SearchOption.AllDirectories)) {
                    string rel = Path.GetRelativePath(baseDir, full).Replace('\\', '/');
                    list.Add(new PackFileEntry { Index = index++, Name = rel });
                }
            }
            Files = list;
        }

        private string PathOf(PackFileEntry entry) => Path.Combine(baseDir, entry.Name.Replace('/', Path.DirectorySeparatorChar));

        public override byte[] GetBytes(PackFileEntry entry) => System.IO.File.ReadAllBytes(PathOf(entry));

        public override string GetString(PackFileEntry entry) {
            // File.ReadAllText detects and strips a UTF-8 BOM automatically (matching M2dReader.GetString, which
            // strips U+FEFF), so no manual BOM handling is needed here.
            return System.IO.File.ReadAllText(PathOf(entry));
        }

        public override XmlReader GetXmlReader(PackFileEntry entry) {
            return XmlReader.Create(new MemoryStream(GetBytes(entry)));
        }

        public override XmlDocument GetXmlDocument(PackFileEntry entry) {
            var document = new XmlDocument();
            byte[] data = GetBytes(entry);
            try {
                document.Load(new MemoryStream(data));
            } catch {
                document.LoadXml(Encoding.Default.GetString(data));
            }
            return document;
        }
    }
}

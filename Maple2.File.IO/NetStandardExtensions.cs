using System.Collections.Generic;
using System.Numerics;

namespace Maple2.File.IO;

#if NETSTANDARD2_1
public static class NetStandardExtensions {
    // EnsureCapacity for netstandard2.1 (added in .NET 5)
    public static void EnsureCapacityCompat<T>(this List<T> list, int capacity) {
        if (list.Capacity < capacity) {
            list.Capacity = capacity;
        }
    }

    // Matrix4x4 indexer for netstandard2.1
    public static float GetElement(this Matrix4x4 matrix, int row, int column) {
        return column switch {
            0 => row switch {
                0 => matrix.M11,
                1 => matrix.M21,
                2 => matrix.M31,
                3 => matrix.M41,
                _ => 0f
            },
            1 => row switch {
                0 => matrix.M12,
                1 => matrix.M22,
                2 => matrix.M32,
                3 => matrix.M42,
                _ => 0f
            },
            2 => row switch {
                0 => matrix.M13,
                1 => matrix.M23,
                2 => matrix.M33,
                3 => matrix.M43,
                _ => 0f
            },
            3 => row switch {
                0 => matrix.M14,
                1 => matrix.M24,
                2 => matrix.M34,
                3 => matrix.M44,
                _ => 0f
            },
            _ => 0f
        };
    }

    public static Matrix4x4 SetMatrixElement(Matrix4x4 matrix, int row, int column, float value) {
        if (column == 0 && row == 0) matrix.M11 = value;
        else if (column == 0 && row == 1) matrix.M21 = value;
        else if (column == 0 && row == 2) matrix.M31 = value;
        else if (column == 0 && row == 3) matrix.M41 = value;
        else if (column == 1 && row == 0) matrix.M12 = value;
        else if (column == 1 && row == 1) matrix.M22 = value;
        else if (column == 1 && row == 2) matrix.M32 = value;
        else if (column == 1 && row == 3) matrix.M42 = value;
        else if (column == 2 && row == 0) matrix.M13 = value;
        else if (column == 2 && row == 1) matrix.M23 = value;
        else if (column == 2 && row == 2) matrix.M33 = value;
        else if (column == 2 && row == 3) matrix.M43 = value;
        else if (column == 3 && row == 0) matrix.M14 = value;
        else if (column == 3 && row == 1) matrix.M24 = value;
        else if (column == 3 && row == 2) matrix.M34 = value;
        else if (column == 3 && row == 3) matrix.M44 = value;
        return matrix;
    }
}
#endif

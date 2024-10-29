using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien_CTDL
{
    public class SinhVien
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public double diemTB { get; set; }
    }

    public class SearchAlgorithms
    {
        // tim kiem tuan tu
        public static int SequentialSearch(List<SinhVien> students, SinhVien target)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].ID == target.ID)
                    return i;
            }
            return -1;
        }

        // tim kiem de quy
        public static int RecursiveSearch(List<SinhVien> students, int index, SinhVien target)
        {
            if (index >= students.Count)
                return -1;

            if (students[index].ID == target.ID)
                return index;

            return RecursiveSearch(students, index + 1, target);
        }

        // sentinel
        public static int SentinelSearch(List<SinhVien> students, SinhVien target)
        {
            int n = students.Count;
            SinhVien last = students[n - 1];
            students[n - 1] = target;
            int i = 0;
            while (students[i].ID != target.ID)
                i++;
            students[n - 1] = last;
            if ((i < n - 1) || students[n - 1].ID == target.ID)
                return i;
            else
                return -1;
        }

        // nhi phan
        public static int BinarySearch(List<SinhVien> students, SinhVien target)
        {
            int left = 0;
            int right = students.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (students[mid].ID == target.ID)
                    return mid;
                else if (students[mid].ID < target.ID)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> students = new List<SinhVien>
        {
            new SinhVien { ID = 1, HoTen = "Nguyen Van A", diemTB = 8.6 },
            new SinhVien { ID = 2, HoTen = "Nguyen B", diemTB = 7.3 },
            new SinhVien { ID = 3, HoTen = "John Cena", diemTB = 8.0 },
            new SinhVien { ID = 4, HoTen = "Nguyen Thi A", diemTB = 7.8 },
            new SinhVien { ID = 5, HoTen = "Nguyen Van C", diemTB = 9.3 },
            new SinhVien { ID = 6, HoTen = "A Van B", diemTB = 7.1 },
            new SinhVien { ID = 7, HoTen = "Vo Thi A", diemTB = 8.5 },
            new SinhVien { ID = 8, HoTen = "Dang Van D", diemTB = 9.2 },
            new SinhVien { ID = 9, HoTen = "Nguyen Van T", diemTB = 7.7 },
            new SinhVien { ID = 10, HoTen = "Vin Future", diemTB = 8.9 }
        };

            /*
                        Random random = new Random();
                        int randomId = random.Next(1, 11);
                        SinhVien targetSinhVien = new SinhVien { ID = randomId };*/




            //tuan tu
            SinhVien targetSinhVien1 = new SinhVien { ID = 5 };
            int sequentialIndex = SearchAlgorithms.SequentialSearch(students, targetSinhVien1);
            if (sequentialIndex != -1)
            {
                Console.WriteLine($"Sequential Search: Tim thay sinh vien {students[sequentialIndex].ID} - {students[sequentialIndex].HoTen} diem TB la: {students[sequentialIndex].diemTB}");
            }
            else
            {
                Console.WriteLine($"Sequential Search: SinhVien {targetSinhVien1.ID} not found");
            }

            // de quy
           SinhVien targetSinhVien2 = new SinhVien { ID = 8 };
            int recursiveIndex = SearchAlgorithms.RecursiveSearch(students, 0, targetSinhVien2);
            if (recursiveIndex != -1)
            {
                Console.WriteLine($"Recursive Search: Tim thay sinh vien {students[recursiveIndex].ID} - {students[recursiveIndex].HoTen} diem TB la: {students[recursiveIndex].diemTB}");
            }
            else
            {
                Console.WriteLine($"Recursive Search: SinhVien {targetSinhVien2.ID} not found");
            }

            // sentinel
            SinhVien targetSinhVien3 = new SinhVien { ID = 3 };
            int sentinelIndex = SearchAlgorithms.SentinelSearch(students, targetSinhVien3);
            if (sentinelIndex != -1)
            {
                Console.WriteLine($"Sentinel Search: Tim thay sinh vien {students[sentinelIndex].ID} - {students[sentinelIndex].HoTen} diem TB la: {students[sentinelIndex].diemTB}");
            }
            else
            {
                Console.WriteLine($"Sentinel Search: SinhVien {targetSinhVien3.ID} not found");
            }

            // nhi phan (sorted)
            students.Sort((s1, s2) => s1.ID.CompareTo(s2.ID));
            SinhVien targetSinhVien4 = new SinhVien { ID = 7 };
            int binaryIndex = SearchAlgorithms.BinarySearch(students, targetSinhVien4);
            if (binaryIndex != -1)
            {
                Console.WriteLine($"Binary Search: Tim thay sinh vien {students[binaryIndex].ID} - {students[binaryIndex].HoTen} diem TB la: {students[binaryIndex].diemTB}");
            }
            else
            {
                Console.WriteLine($"Binary Search: SinhVien {targetSinhVien4.ID} not found");
            }
        }
    }
}


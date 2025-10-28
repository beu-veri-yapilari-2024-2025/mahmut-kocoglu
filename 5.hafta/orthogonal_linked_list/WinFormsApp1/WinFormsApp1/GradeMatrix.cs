using System;
using System.Collections.Generic;

namespace NotMatrisi
{
    public class GradeNode
    {
        public int StudentNo;
        public string CourseCode;
        public string Letter;

        // Aynı öğrencinin diğer dersi (yatay sağa doğru)
        public GradeNode NextCourse;

        // Aynı dersin diğer öğrencisi (dikey aşağı doğru)
        public GradeNode NextStudent;
    }

    public class GradeMatrix
    {
        // Her öğrencinin ilk dersi
        private Dictionary<int, GradeNode> studentHead = new Dictionary<int, GradeNode>();

        // Her dersin ilk öğrencisi
        private Dictionary<string, GradeNode> courseHead =
            new Dictionary<string, GradeNode>(StringComparer.OrdinalIgnoreCase);

        // Ders sırası 
        private static Dictionary<string, int> courseRank =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                
            };

        // 1) ekle/güncelle
        public void AddOrUpdate(int student, string course, string letter)
        {
            if (!courseRank.ContainsKey(course))
            {
                int nextIndex = courseRank.Count;
                courseRank[course] = nextIndex;
            }

            // varsa güncelle
            GradeNode exist = FindInStudentRow(student, course);
            if (exist != null)
            {
                exist.Letter = letter;
                return;
            }

            // yoksa yeni node
            GradeNode node = new GradeNode();
            node.StudentNo = student;
            node.CourseCode = course;
            node.Letter = letter;

            InsertIntoStudentRowSorted(student, node);
            InsertIntoCourseColSorted(course, node);
        }

        // 3-4) sil
        public bool Remove(int student, string course)
        {
            if (!studentHead.TryGetValue(student, out GradeNode sHead)) return false;
            if (!courseHead.TryGetValue(course, out GradeNode cHead)) return false;

            GradeNode target = FindInStudentRow(student, course);
            if (target == null) return false;

            studentHead[student] = RemoveFromStudentRow(sHead, course);
            courseHead[course] = RemoveFromCourseCol(cHead, student);

            if (studentHead[student] == null) studentHead.Remove(student);
            if (courseHead[course] == null) courseHead.Remove(course);

            return true;
        }

        // 6) öğrencinin derslerini sırayla listele
        public IEnumerable<Tuple<string, string>> ListCoursesOfStudent(int student)
        {
            if (!studentHead.TryGetValue(student, out GradeNode cur) || cur == null)
                yield break;

            while (cur != null)
            {
                yield return Tuple.Create(cur.CourseCode, cur.Letter);
                cur = cur.NextCourse;
            }
        }

        // 5) dersteki öğrencileri numaraya göre listele
        public IEnumerable<Tuple<int, string>> ListStudentsOfCourse(string course)
        {
            if (!courseHead.TryGetValue(course, out GradeNode cur) || cur == null)
                yield break;

            while (cur != null)
            {
                yield return Tuple.Create(cur.StudentNo, cur.Letter);
                cur = cur.NextStudent;
            }
        }

        // -------- yardımcılar --------

        private GradeNode FindInStudentRow(int student, string course)
        {
            if (!studentHead.TryGetValue(student, out GradeNode cur)) return null;
            while (cur != null)
            {
                if (string.Equals(cur.CourseCode, course, StringComparison.OrdinalIgnoreCase))
                    return cur;
                cur = cur.NextCourse;
            }
            return null;
        }

        private void InsertIntoStudentRowSorted(int student, GradeNode node)
        {
            if (!studentHead.TryGetValue(student, out GradeNode head) || head == null)
            {
                studentHead[student] = node;
                return;
            }

            // başa girecek mi?
            if (courseRank[node.CourseCode] < courseRank[head.CourseCode])
            {
                node.NextCourse = head;
                studentHead[student] = node;
                return;
            }

            GradeNode prev = head;
            GradeNode cur = head.NextCourse;
            while (cur != null && courseRank[cur.CourseCode] <= courseRank[node.CourseCode])
            {
                prev = cur;
                cur = cur.NextCourse;
            }
            node.NextCourse = cur;
            prev.NextCourse = node;
        }

        private void InsertIntoCourseColSorted(string course, GradeNode node)
        {
            if (!courseHead.TryGetValue(course, out GradeNode head) || head == null)
            {
                courseHead[course] = node;
                return;
            }

            // başa mı?
            if (node.StudentNo < head.StudentNo)
            {
                node.NextStudent = head;
                courseHead[course] = node;
                return;
            }

            GradeNode prev = head;
            GradeNode cur = head.NextStudent;
            while (cur != null && cur.StudentNo <= node.StudentNo)
            {
                prev = cur;
                cur = cur.NextStudent;
            }
            node.NextStudent = cur;
            prev.NextStudent = node;
        }

        private GradeNode RemoveFromStudentRow(GradeNode head, string course)
        {
            GradeNode prev = null;
            GradeNode cur = head;
            while (cur != null)
            {
                if (string.Equals(cur.CourseCode, course, StringComparison.OrdinalIgnoreCase))
                {
                    if (prev == null) return cur.NextCourse; // başı siliyoruz
                    prev.NextCourse = cur.NextCourse;
                    return head;
                }
                prev = cur;
                cur = cur.NextCourse;
            }
            return head;
        }

        private GradeNode RemoveFromCourseCol(GradeNode head, int student)
        {
            GradeNode prev = null;
            GradeNode cur = head;
            while (cur != null)
            {
                if (cur.StudentNo == student)
                {
                    if (prev == null) return cur.NextStudent; // başı siliyoruz
                    prev.NextStudent = cur.NextStudent;
                    return head;
                }
                prev = cur;
                cur = cur.NextStudent;
            }
            return head;
        }
    }
}

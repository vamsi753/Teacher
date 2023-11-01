using System;
using System.Collections.Generic;
using System.IO;

public class TeacherRepository
{
    private List<Teacher> teachers;
    private const string dataFile = "teacher_data.txt";

    public TeacherRepository()
    {
        teachers = new List<Teacher>();
        LoadData();
    }

    public void LoadData()
    {
        if (File.Exists(dataFile))
        {
            string[] lines = File.ReadAllLines(dataFile);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string className = parts[2];
                    string section = parts[3];
                    teachers.Add(new Teacher { ID = id, Name = name, Class = className, Section = section });
                }
            }
        }
    }

    public void SaveData()
    {
        List<string> lines = new List<string>();
        foreach (Teacher teacher in teachers)
        {
            string line = $"{teacher.ID},{teacher.Name},{teacher.Class},{teacher.Section}";
            lines.Add(line);
        }
        File.WriteAllLines(dataFile, lines);
    }

    public List<Teacher> GetAllTeachers()
    {
        return teachers;
    }

    public void AddTeacher(Teacher teacher)
    {
        teachers.Add(teacher);
        SaveData();
    }

    public bool UpdateTeacher(int id, string name, string className, string section)
    {
        Teacher teacherToUpdate = teachers.Find(t => t.ID == id);
        if (teacherToUpdate != null)
        {
            teacherToUpdate.Name = name;
            teacherToUpdate.Class = className;
            teacherToUpdate.Section = section;
            SaveData();
            return true;
        }
        return false;
    }

    public Teacher GetTeacherByID(int id)
    {
        return teachers.Find(t => t.ID == id);
    }

    public List<Teacher> SearchTeacherByName(string name)
    {
        return teachers.FindAll(t => t.Name.ToLower().Contains(name.ToLower()));
    }
}

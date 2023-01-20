using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApplication5.Models;
namespace WebApplication5.Irep
{
    public interface EmployI
    {

        List<Student> GetAllstudents();


        string Delete(string stu_name);
        string Insert(Student name);
        string Update(Student c);


        string BulkDelete(List<student> y);

        string BulkInsert(List<Student> x);
       student Getid(int id);
    }

    class EmpIc : EmployI
    {
        mouniEntities sb = new mouniEntities();
        List<Student> EmployI.GetAllstudents()
        {
            List<Student> EmpList = sb.students.Select(s => new Student()

            {
                stu_id = s.stu_id,
                stu_name = s.stu_name,
                stu_phoneno = s.stu_phoneno,
                stu_email_id = s.stu_email_id,
                stu_ranking = s.stu_ranking,
                stu_branch = s.stu_branch,
                empid = s.empid

            }).ToList<Student>();
            return EmpList;
        }

        string EmployI.Delete(string stud_name)
        {
            if (stud_name != null)
            {
                var A = sb.students.Where(u => u.stu_name  == stud_name).FirstOrDefault();
                if (A != null)
                {
                    sb.students.Remove(A);
                }
                sb.SaveChanges();
                return "Deleted";
            }
            return "pls enter values";
        }

        string EmployI.Insert(Student name)
        {

            var B = sb.students.Where(c => c.stu_name == name.stu_name).FirstOrDefault();
            if (B == null)
            {
                sb.students.Add(new student
                {

                    stu_id = name.stu_id,
                    stu_name = name.stu_name,
                    stu_phoneno = name.stu_phoneno,
                    stu_email_id = name.stu_email_id,
                    stu_ranking = name.stu_ranking,
                    stu_branch = name.stu_branch,
                    empid = name.empid

                });
                sb.SaveChanges();
                sb.Dispose();


                return "updated";
            }
            return "not  success";
        }
        string EmployI.Update(Student c)
        {
            var bc = sb.students.Where(s => s.empid == c.empid).FirstOrDefault();
            if (bc != null)
            {
                bc.stu_email_id = c.stu_email_id;

            }

            sb.SaveChanges();
            sb.Dispose();
            return "Updated";

        }


        string EmployI.BulkDelete(List<student> y)
        {
            foreach (var del in sb.students)
            {
                sb.students.Remove(del);

            }
            sb.SaveChanges();
            return "Bulk deleted";
        }

        //string BulkInsert(List<student> t)
        string EmployI.BulkInsert(List<Student> x)
        {
            foreach (Student ins in x)
            {
                var D = sb.students.Where(v => v.stu_name == ins.stu_name).FirstOrDefault();
                if (D == null)
                {
                    sb.students.Add(new student
                    {
                        stu_id = ins.stu_id,
                        stu_name = ins.stu_name,
                        stu_phoneno = ins.stu_phoneno,
                        stu_email_id = ins.stu_email_id,
                        stu_ranking = ins.stu_ranking,
                        stu_branch = ins.stu_branch,
                        empid = ins.empid,

                    });
                    sb.SaveChanges();
                }
            }
            return "Bulk inserted";
        }
        student EmployI.Getid(int id)
        {
            
            var emplist = sb.students.FirstOrDefault(a => a.stu_id == id);
            return emplist;
        }
    }
}



        

      
    


 


             






           

       





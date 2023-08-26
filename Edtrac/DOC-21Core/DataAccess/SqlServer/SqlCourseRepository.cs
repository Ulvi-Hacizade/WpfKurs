using DOC_21Core.Domain.Abstract;
using DOC_21Core.Domain.Entities;
using DOC_21Core.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21Core.DataAccess.SqlServer
{
    public class SqlCourseRepository : SqlBaseRepository, ICourseRepository
    {
        public SqlCourseRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Course course)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {  
                conn.Open();
                string query = @"Insert into Courses output inserted.Id 
                                values(@EventName, @Date, @EventLocation, @OrganizersInformations, @InstructorsInformations,@Participants, 
@Note, @DocumentNumber, @EmployeeRank, @EmployeeName, @EmployeeSurname, @IsDeleted, @CreationDate, @UserId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventName", course.EventName);
                    cmd.Parameters.AddWithValue("@Date", course.Date);
                    cmd.Parameters.AddWithValue("@EventLocation", course.EventLocation);
                    cmd.Parameters.AddWithValue("@OrganizersInformations", course.OrganizersInformations ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@InstructorsInformations", course.InstructorsInformations ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Participants", course.Participants ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Note", course.Note ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DocumentNumber", course.DocumentNumber);
                   
                    cmd.Parameters.AddWithValue("@EmployeeRank", course.EmployeeRank);
                    cmd.Parameters.AddWithValue("@EmployeeName", course.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeSurname", course.EmployeeSurname);
                    cmd.Parameters.AddWithValue("@IsDeleted", course.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", course.CreationDate);
                    cmd.Parameters.AddWithValue("@UserId", course.Creator.Id);


                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "delete from Courses where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Course FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Courses where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Course course = null;

                    if (reader.Read())
                    {
                        course = GetDataFromReader(reader);
                    }

                    return course;
                }
            }
        }

        public List<Course> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Courses where IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Course> courses = new List<Course>();

                    while (reader.Read())
                    {
                        Course course = GetDataFromReader(reader);
                        courses.Add(course);
                    }

                    return courses;
                }
            }
        }

        public bool Update(Course course)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();

                string query = @"Update Courses 
                    set EventName=@EventName, Date=@Date, EventLocation=@EventLocation, 
                    OrganizersInformations=@OrganizersInformations, InstructorsInformations=@InstructorsInformations, 
                    Participants=@Participants,
                    DocumentNumber=@DocumentNumber,
                    Note=@Note, EmployeeRank=@EmployeeRank, EmployeeName=@EmployeeName, EmployeeSurname=@EmployeeSurname, IsDeleted=@IsDeleted, 
                    CreationDate=@CreationDate, UserId=@UserId
                    where Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", course.Id);
                    cmd.Parameters.AddWithValue("@EventName", course.EventName);
                    cmd.Parameters.AddWithValue("@Date", course.Date);
                    cmd.Parameters.AddWithValue("@EventLocation", course.EventLocation);
                    cmd.Parameters.AddWithValue("@OrganizersInformations", course.OrganizersInformations);
                    cmd.Parameters.AddWithValue("@InstructorsInformations", course.InstructorsInformations);

                    cmd.Parameters.AddWithValue("@Participants", course.Participants);
                    cmd.Parameters.AddWithValue("@DocumentNumber", course.DocumentNumber);
                    cmd.Parameters.AddWithValue("@Note", course.Note ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmployeeRank", course.EmployeeRank);
                    cmd.Parameters.AddWithValue("@EmployeeName", course.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeSurname", course.EmployeeSurname);
                    cmd.Parameters.AddWithValue("@IsDeleted", course.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", course.CreationDate);
                    cmd.Parameters.AddWithValue("@UserId", course.Creator.Id);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }

        }
        private Course GetDataFromReader(SqlDataReader reader)
        {
            Course course = new Course();

            course.Id = reader.GetInt32("Id");
            course.EventName = reader.GetString("EventName");
            course.Date = reader.GetDateTime("Date");
            course.EventLocation = reader.GetString("EventLocation");
            course.OrganizersInformations = reader.GetString("OrganizersInformations");
            course.InstructorsInformations = reader.GetString("InstructorsInformations");
            course.Participants= reader.GetString("Participants");
            course.Note = reader.GetString("Note");
            course.DocumentNumber = reader.GetString("DocumentNumber");
            course.EmployeeRank = reader.GetString("EmployeeRank");
            course.EmployeeName = reader.GetString("EmployeeName");
            course.EmployeeSurname = reader.GetString("EmployeeSurname");
            course.IsDeleted = reader.GetBoolean("IsDeleted");
            course.CreationDate = reader.GetDateTime("CreationDate");
            course.Creator = new User() { Id = reader.GetInt32("UserId") };
            

            return course;
        }

    }
}

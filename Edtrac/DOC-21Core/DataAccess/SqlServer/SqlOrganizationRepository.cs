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
    public class SqlOrganizationRepository : SqlBaseRepository, IOrganizationRepository
    {

        public SqlOrganizationRepository(SqlContext context) : base(context)
        {
        }
        public int Add(Organization organization)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open(); 
                string query = @"Insert into Organizations output inserted.Id 
                                values(@Surname, @Name, @FatherName, @OrganizationName, @ActivityInformation, @DocumentRegistrationNumber, @DocumentRegistrationDate,
                                 @Note, @EmployeeRank, @EmployeeName, @EmployeeSurname, @IsDeleted, @CreationDate, @UserId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Surname", organization.Surname ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", organization.Name ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FatherName", organization.FatherName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@OrganizationName", organization.OrganizationName);
                    cmd.Parameters.AddWithValue("@ActivityInformation", organization.ActivityInformation ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DocumentRegistrationNumber", organization.DocumentRegistrationNumber);
                    cmd.Parameters.AddWithValue("@DocumentRegistrationDate", organization.DocumentRegistrationDate);
                    cmd.Parameters.AddWithValue("@Note", organization.Note ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmployeeRank", organization.EmployeeRank);
                    cmd.Parameters.AddWithValue("@EmployeeName", organization.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeSurname", organization.EmployeeSurname);
                    cmd.Parameters.AddWithValue("@IsDeleted", organization.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", organization.CreationDate);
                    cmd.Parameters.AddWithValue("@UserId", organization.Creator.Id);


                  //  cmd.Parameters.AddWithValue("@Note", branch.Note ?? (object)DBNull.Value);
                   

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "delete from Organizations where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Organization FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Organizations where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Organization organization = null;

                    if (reader.Read())
                    {
                        organization = GetDataFromReader(reader);
                    }

                    return organization;
                }
            }
        }

        public List<Organization> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Organizations where IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Organization> organizations = new List<Organization>();

                    while (reader.Read())
                    {
                        Organization organization = GetDataFromReader(reader);
                        organizations.Add(organization);
                    }

                    return organizations;
                }
            }
        }

        public bool Update(Organization organization)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();

                string query = @"Update Organizations 
                    set Surname=@Surname, Name=@Name, FatherName=@FatherName, OrganizationName=@OrganizationName, ActivityInformation=@ActivityInformation,
                    DocumentRegistrationNumber=@DocumentRegistrationNumber, DocumentRegistrationDate=@DocumentRegistrationDate,
                    Note=@Note, EmployeeRank=@EmployeeRank, EmployeeName=@EmployeeName, EmployeeSurname=@EmployeeSurname, IsDeleted=@IsDeleted, 
                    CreationDate=@CreationDate, UserId=@UserId
                    where Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", organization.Id);
                    cmd.Parameters.AddWithValue("@Surname", organization.Surname);
                    cmd.Parameters.AddWithValue("@Name", organization.Name);
                    cmd.Parameters.AddWithValue("@FatherName", organization.FatherName);
                    cmd.Parameters.AddWithValue("@OrganizationName", organization.OrganizationName);
                    cmd.Parameters.AddWithValue("@ActivityInformation", organization.ActivityInformation);
                    cmd.Parameters.AddWithValue("@DocumentRegistrationNumber", organization.DocumentRegistrationNumber);
                    cmd.Parameters.AddWithValue("@DocumentRegistrationDate", organization.DocumentRegistrationDate);
                    cmd.Parameters.AddWithValue("@Note", organization.Note ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmployeeRank", organization.EmployeeRank);
                    cmd.Parameters.AddWithValue("@EmployeeName", organization.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeSurname", organization.EmployeeSurname);                  
                    cmd.Parameters.AddWithValue("@IsDeleted", organization.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", organization.CreationDate);
                    cmd.Parameters.AddWithValue("@UserId", organization.Creator.Id);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }

        }

        private Organization GetDataFromReader(SqlDataReader reader)
        {
            Organization organization = new Organization();

            organization.Id = reader.GetInt32("Id");
            organization.Surname = reader.GetString("Surname");
            organization.Name = reader.GetString("Name");
            organization.FatherName = reader.GetString("FatherName");
            organization.OrganizationName = reader.GetString("OrganizationName");
            organization.ActivityInformation = reader.GetString("ActivityInformation");
            organization.DocumentRegistrationNumber = reader.GetString("DocumentRegistrationNumber");
            organization.DocumentRegistrationDate = reader.GetDateTime("DocumentRegistrationDate");
            organization.EmployeeRank = reader.GetString("EmployeeRank");
            organization.EmployeeName = reader.GetString("EmployeeName");
            organization.EmployeeSurname = reader.GetString("EmployeeSurname");
            organization.IsDeleted = reader.GetBoolean("IsDeleted");
            organization.CreationDate = reader.GetDateTime("CreationDate");
            organization.Creator = new User() { Id = reader.GetInt32("UserId") };
            organization.Note = reader.GetString("Note");

            return organization;
        }
    }
}

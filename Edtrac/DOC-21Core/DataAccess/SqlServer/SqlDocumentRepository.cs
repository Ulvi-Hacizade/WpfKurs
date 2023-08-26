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
    public class SqlDocumentRepository : SqlBaseRepository, IDocumentRepository
    {
        public SqlDocumentRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Document document)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Documents output inserted.Id 
                                values(@DocumentName, @DocumentCreator, @DocumentRegistrationDate, @DocumentRegistrationNumber, @DocumentContent, 
                                 @Note, @IsDeleted, @CreationDate, @UserId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DocumentName", document.DocumentName);
                    cmd.Parameters.AddWithValue("@DocumentCreator", document.DocumentCreator);
                    cmd.Parameters.AddWithValue("@DocumentRegistrationDate", document.DocumentRegistrationDate);
                    cmd.Parameters.AddWithValue("@DocumentRegistrationNumber", document.DocumentRegistrationNumber);
                    cmd.Parameters.AddWithValue("@DocumentContent", document.DocumentContent);
                    cmd.Parameters.AddWithValue("@Note", document.Note ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsDeleted", document.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", document.CreationDate);
                    cmd.Parameters.AddWithValue("@UserId", document.Creator.Id);


                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "delete from Documents where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Document FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Documents where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Document document = null;

                    if (reader.Read())
                    {
                        document = GetDataFromReader(reader);
                    }

                    return document;
                }
            }
        }

        public List<Document> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Documents where IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Document> documents = new List<Document>();

                    while (reader.Read())
                    {
                        Document document = GetDataFromReader(reader);
                        documents.Add(document);
                    }

                    return documents;
                }
            }
        }

        public bool Update(Document document)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();

                string query = @"Update Documents 
                    set DocumentName=@DocumentName, DocumentCreator=@DocumentCreator, DocumentRegistrationDate=@DocumentRegistrationDate, 
                    DocumentRegistrationNumber=@DocumentRegistrationNumber, DocumentContent=@DocumentContent, 
                    Note=@Note, IsDeleted=@IsDeleted, 
                    CreationDate=@CreationDate, UserId=@UserId
                    where Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", document.Id);
                    cmd.Parameters.AddWithValue("@DocumentName", document.DocumentName);
                    cmd.Parameters.AddWithValue("@DocumentCreator", document.DocumentCreator);
                    cmd.Parameters.AddWithValue("@DocumentRegistrationDate", document.DocumentRegistrationDate);
                    cmd.Parameters.AddWithValue("@DocumentRegistrationNumber", document.DocumentRegistrationNumber);
                    cmd.Parameters.AddWithValue("@DocumentContent", document.DocumentContent);

                   
                    cmd.Parameters.AddWithValue("@Note", document.Note ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@IsDeleted", document.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", document.CreationDate);
                    cmd.Parameters.AddWithValue("@UserId", document.Creator.Id);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }

        }

        private Document GetDataFromReader(SqlDataReader reader)
        {
            Document document = new Document();

            document.Id = reader.GetInt32("Id");
            document.DocumentName = reader.GetString("DocumentName");
            document.DocumentCreator = reader.GetString("DocumentCreator");
            document.DocumentRegistrationDate = reader.GetDateTime("DocumentRegistrationDate");

            document.DocumentRegistrationNumber = reader.GetString("DocumentRegistrationNumber");
            document.DocumentContent = reader.GetString("DocumentContent");
            document.Note = reader.GetString("Note");

            document.IsDeleted = reader.GetBoolean("IsDeleted");
            document.CreationDate = reader.GetDateTime("CreationDate");
            document.Creator = new User() { Id = reader.GetInt32("UserId") };


            return document;
        }
    }
}

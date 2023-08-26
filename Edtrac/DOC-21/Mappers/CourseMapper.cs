using DOC_21.Models;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Mappers
{
    public class CourseMapper
    {
        public static CourseModel Map(Course course)
        {
            var model = new CourseModel();
            model.Id = course.Id;
            model.EventName = course.EventName;
            model.Date = course.Date;
            model.EventLocation = course.EventLocation;
            model.OrganizersInformations = course.OrganizersInformations;
            model.InstructorsInformations = course.InstructorsInformations;
            model.Participants = course.Participants;
            model.DocumentNumber = course.DocumentNumber;
            model.Note = course.Note;
            model.EmployeeRank = course.EmployeeRank;
            model.EmployeeName = course.EmployeeName;
            model.EmployeeSurname = course.EmployeeSurname;

            return model;
        }

        public static Course Map(CourseModel model, Course destination)
        {
            destination.Id = model.Id;
            destination.EventName = model.EventName;
            destination.Date = model.Date;
            destination.EventLocation = model.EventLocation;
            destination.OrganizersInformations = model.OrganizersInformations;
            destination.InstructorsInformations = model.InstructorsInformations;
            destination.Participants = model.Participants;
            destination.DocumentNumber = model.DocumentNumber;
            destination.Note = model.Note;
            destination.EmployeeRank = model.EmployeeRank;
            destination.EmployeeName = model.EmployeeName;
            destination.EmployeeSurname = model.EmployeeSurname;

            return destination;
        }
    }
}

using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.CloudServices.Aws.Models
{
    [DynamoDBTable("Student")]
    public class Student
    {
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string collegeName { get; set; }
        public string className { get; set; }
        public int isActive { get; set; }
    }
}
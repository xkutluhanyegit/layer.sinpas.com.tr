using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace infrastracture.externalservices.meyerapi.models
{
    public class meyersetsicil
    {
        public string COMPANY_ID { get; set; }
        public string EMP_NO { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string PICTURE_ID { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string SEX { get; set; }
        public string BLOOD_TYPE { get; set; }
        public string EMPLOYEE_STATUS { get; set; }
        public string DATE_OF_EMPLOYMENT { get; set; }
        public string DATE_OF_LEAVING { get; set; }
    }
}
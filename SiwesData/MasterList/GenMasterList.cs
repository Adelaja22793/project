using System;
using System.Collections.Generic;
using System.Text;
using SiwesData;

namespace SiwesData.MasterList
{
    class GenMasterList
    {
        public int Id {get;set;}
        public string MatricNo { get; set; }
        public string Email { get; set; }
        public string GenYear { get; set; }
        public string SiwesYear { get; set; }
        public string BatchNo  { get; set; }
        public string SentforAppr  { get; set; }
        public DateTime Gendate { get; set; }
        public string ApprStatus { get; set; }
        public int InstitutionId { get; set; }
        public Setup.Institution Institution { get; set; }
        public string AppUserTabId { get; set; }
        public  AppUserTab AppUserTab { get; set; }


    }
}

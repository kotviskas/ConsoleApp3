using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class ExcelPage
	{
		public List<ExcelData> results { get; set; }
	}

	class ExcelData
	{
        public List<Cell>? cells { get; set; }
        public string? cells_title { get; set; }
        //public List<Cell>? cells_tittle { get; set; }
        public string? cfaaqm { get; set; }
        public string? first_name { get; set; }
		public string? last_name { get; set; }
		public string? patronymic { get; set; }
		public string? birthday { get; set; }
		public string? address { get; set; }
		public string? phone_mobile_digits { get; set; }
		public string? created_at { get; set; }
        public string? region_name { get; set; }
        public string? branch_name { get; set; }
        public bool? is_foreman { get; set; }
        public string? activism { get; set; }
        public object? email { get; set; }
        public int? foreman_id { get; set; }
        public int? id { get; set; }
        public object? ig { get; set; }
        public string? cfaajg { get; set; }
        public string? cfaaqt { get; set; }
        public string? cfaazn { get; set; }
        public bool? is_mger { get; set; }
        public bool? is_party_loyal { get; set; }
        public bool? is_president_loyal { get; set; }
        public bool? is_regional { get; set; }
        public bool? is_up { get; set; }
        public string? loyalty { get; set; }
        public string? membership { get; set; }
        public int? uik_n { get; set; }
        public object? ok { get; set; }
        public string? pdp_consent_date { get; set; }
        public string? pdp_consent_title { get; set; }
        public string? phone_home { get; set; }
        public bool? cfaaqm__eq { get; set; }
        public string? phone_mobile { get; set; }
        public object? tiktok { get; set; }
        public DateTime? updated_at { get; set; }
        public int? updated_by { get; set; }
        public object? vk { get; set; }
        public string? workplace { get; set; }
        public string? workposition { get; set; }
        public string? sraasz { get; set; }
        public string? sraaxx { get; set; }
    }
}

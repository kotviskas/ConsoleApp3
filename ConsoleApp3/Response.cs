using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Foreman
    {
        public int id { get; set; }
        public DateTime? birthday { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string patronymic { get; set; }
    }

    public class Cell
    {
        public int? id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
    }
    public class Result
    {
        public List<Cell> cells { get; set; }
        public bool? bfaafl { get; set; }
        public object? bfaagd { get; set; }
        public object? sraajw { get; set; }
        public object? sfaahs { get; set; }
        public object? sfaaht { get; set; }
        public string? sfaahv { get; set; }
        public object? sfaahx { get; set; }
        public object? sfaahw { get; set; }
        public string? sfaahu { get; set; }
        public string? sfaahr { get; set; }
        public bool? bfaaoo { get; set; }
        public bool? bfaant { get; set; }
        public bool? bfaaop { get; set; }
        public string? sfaabz { get; set; }
        public object? braapk { get; set; }
        public string? cfaajg { get; set; }
        public string? cfaaqm { get; set; }
        public string? cfaaqt { get; set; }
        public string? cfaazn { get; set; }
        public bool? cfaaqm__eq { get; set; }
        public bool? bfaadp { get; set; }
        public object? braapl { get; set; }
        public object? sfaale { get; set; }
        public object? sfaalf { get; set; }
        public object? sfaalc { get; set; }
        public object? sfaald { get; set; }
        public object? cfaahy { get; set; }
        public object? bfaagm { get; set; }
        public string? region_name { get; set; }
        public string? branch_name { get; set; }
        public int? uik_n { get; set; }
        public Foreman? foreman { get; set; }
        public bool? is_foreman { get; set; }
        public string? activism { get; set; }
        public string? address { get; set; }
        public string? birthday { get; set; }
        public int? branch_id { get; set; }
        public DateTime? created_at { get; set; }
        public int? created_by { get; set; }
        public object? email { get; set; }
        public object? fb { get; set; }
        public string? first_name { get; set; }
        public int? foreman_id { get; set; }
        public int? id { get; set; }
        public object? ig { get; set; }
        public bool? is_mger { get; set; }
        public bool? is_party_loyal { get; set; }
        public bool? is_president_loyal { get; set; }
        public bool? is_regional { get; set; }
        public bool? is_up { get; set; }
        public string? last_name { get; set; }
        public string? loyalty { get; set; }
        public string? membership { get; set; }
        public object? mger_level { get; set; }
        public object? mger_status { get; set; }
        public object? my_world { get; set; }
        public string? notes { get; set; }
        public object? ok { get; set; }
        public string? patronymic { get; set; }
        public string? pdp_consent_date { get; set; }
        public string? pdp_consent_title { get; set; }
        public string? phone_home { get; set; }
        public string? phone_mobile { get; set; }
        public string? phone_mobile_digits { get; set; }
        public int? region_id { get; set; }
        public List<object>? status { get; set; }
        public object? tiktok { get; set; }
        public object? tw { get; set; }
        public int? uik_id { get; set; }
        public DateTime? updated_at { get; set; }
        public int? updated_by { get; set; }
        public int? verified { get; set; }
        public object? vk { get; set; }
        public string? workplace { get; set; }
        public string? workposition { get; set; }
        public string? sraasz { get; set; }
        public string? sraaxx { get; set; }
    }

    class Response
    {
        public int count { get; set; }
        public List<Result> results { get; set; }
    }
}

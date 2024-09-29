namespace DTO.Entity
{
    public class Shipping
    {
        public int id { get; set; }
        public string start_adress { get; set; }
        public string destination { get; set; }
        public string status { get; set; } = "Waiting for approve";
        public DateTimeOffset start_date { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset destination_date { get; set; } = DateTimeOffset.Now.AddDays(1);
        public int goods_id { get; set; }
    }
}

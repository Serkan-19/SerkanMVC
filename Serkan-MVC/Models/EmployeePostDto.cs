namespace Serkan_MVC.Models
{
    public class EmployeePostDto
    {
        public int isciNo { get; set; }
        public string? iscininAdi { get; set; }
        public string? iscininSoyadi { get; set; }
        public string? iscininSehiri { get; set; }
        public DateTime? iscininDogumTarihi { get; set; }
        public string? gemiAdi { get; set; }
        public DateTime? gemiCikisTarihi { get; set; }
    }
}

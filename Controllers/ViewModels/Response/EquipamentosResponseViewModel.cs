namespace gr2_api.Controllers.ViewModels.Response
{
    public class EquipamentosResponseViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public EquipamentosResponseViewModel equipamentosResponseViewModel
        {
            get => this;
            set
            {
                Id = value.Id;
                Nome = value.Nome;
            }
        }
    }
}
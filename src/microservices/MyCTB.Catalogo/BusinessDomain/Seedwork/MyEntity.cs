using System.ComponentModel.DataAnnotations;

namespace MyCTB.Catalogo.BusinessDomain
{
    public abstract class MyEntity
    {
        public int Id { get; private set; }
        
        internal string? CreatedBy { get; private set; }
        
        internal string? UpdatedBy { get; private set; }
        
        [ConcurrencyCheck]
        public DateTime? UpdatedDate { get; private set; }

        public void Set_Id(int value)
            => this.Id = value;

        public void Set_CreatedBy(string? value)
        {
            if (String.IsNullOrEmpty(value))
            {
                CreatedBy = "";
            }
            else
            {
                this.CreatedBy = value;
            }
        }

        public void Set_Last_UpdatedDate(DateTime? value)
        {
            this.UpdatedDate = value;
        }

        public void Set_UpdatedBy(string? value)
        {
            if (String.IsNullOrEmpty(value))
            {
                this.UpdatedBy = "";
            }
            else
            {
                this.UpdatedBy = value;
            }
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace MyCTB.Catalogo.BusinessDomain
{
    public abstract class MyEntity
    {
        public int Id { get; private set; }
        
        internal string? Created_By { get; private set; }
        
        internal string? Updated_By { get; private set; }
        
        [ConcurrencyCheck]
        public DateTime? Updated_Date { get; private set; }

        public void Set_Id(int value)
            => this.Id = value;

        public void Set_CreatedBy(string? value)
        {
            if (String.IsNullOrEmpty(value))
            {
                Created_By = "";
            }
            else
            {
                this.Created_By = value;
            }
        }

        public void Set_Last_UpdatedDate(DateTime? value)
        {
            this.Updated_Date = value;
        }

        public void Set_UpdatedBy(string? value)
        {
            if (String.IsNullOrEmpty(value))
            {
                this.Updated_By = "";
            }
            else
            {
                this.Updated_By = value;
            }
        }
    }
}
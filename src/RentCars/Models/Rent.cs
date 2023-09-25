using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        this.Vehicle = vehicle;
        this.Person = person;
        this.DaysRented = daysRented;
        this.Price = this.Person is PhysicalPerson ? this.DaysRented * this.Vehicle.PricePerDay : this.DaysRented * this.Vehicle.PricePerDay *0.9;
        this.Status = RentStatus.Confirmed;
        this.Vehicle.IsRented = true;
        this.Person.Debit = this.Price;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel(int daysLeft)
    {
        this.Status = RentStatus.Canceled;
        this.Vehicle.IsRented = false;
        this.Person.Debit = (DaysRented - daysLeft) * this.Vehicle.PricePerDay * 1.5; 
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        this.Status = RentStatus.Finished;
        this.Vehicle.IsRented = false;
    }
}
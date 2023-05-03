using Microsoft.EntityFrameworkCore;
using polyclinic.Models;
using System.ComponentModel.DataAnnotations;

namespace polyclinic
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region City
            City cityOne = new City()
            {
                Id = 1,
                Name = "Тирасполь"
            };
            City cityTwo = new City()
            {
                Id = 2,
                Name = "Бендеры"
            };
            City cityThree = new City()
            {
                Id = 3,
                Name = "Каменка"
            };
            City cityFour = new City()
            {
                Id = 4,
                Name = "Слободзея"
            };
            City cityFive = new City()
            {
                Id = 5,
                Name = "Григориополь"
            };
            #endregion

            #region Polycnic
            Polyclinic polyclinicOne = new Polyclinic()
            {
                Id = 1,
                Name = "Поликлиника №1",
                CityId = cityOne.Id,
                Address = "Гагарина 11",
                //City = cityOne,
                Phone = "21313",
                Photo = ""
            };
            Polyclinic polyclinicTwo = new Polyclinic()
            {
                Id = 2,
                Name = "Поликлиника №2",
                CityId = cityTwo.Id,
                Address = "Гагарина 21",
                //City = cityTwo,
                Phone = "21213",
                Photo = ""
            };
            Polyclinic polyclinicThree = new Polyclinic()
            {
                Id = 3,
                Name = "Поликлиника №3",
                CityId = cityThree.Id,
                Address = "Гагарина 31",
                //City = cityThree,
                Phone = "23213",
                Photo = ""
            };
            #endregion

            #region Medic
            Medic medicOne = new Medic()
            {
                Id = 1,
                Description = "Врач",
                Experience = "10 лет",
                FullDescription = "Классный врач",
                FullName = "Валерий Леонтьев Педросович",
                Phone = "111111",
                Photo = "",
                Price = 121,
            };
            Medic medicTwo = new Medic()
            {
                Id = 2,
                Description = "Врач",
                Experience = "20 лет",
                FullDescription = "Очень классный врач",
                FullName = "Григорий Леонтьев Педросович",
                Phone = "22222",
                Photo = "",
                Price = 222,
            };
            Medic medicThree = new Medic()
            {
                Id = 3,
                Description = "Врач",
                Experience = "30 лет",
                FullDescription = "Супер врач",
                FullName = "Владислав Кириленко Васильевич",
                Phone = "33333",
                Photo = "",
                Price = 332,
            };
            #endregion

            #region Specialization
            Specialization specializationOne = new Specialization()
            {
                Id = 1,
                Name = "Психолог",
                //Medic = medicOne,
                MedicId = medicOne.Id
            };
            Specialization specializationTwo = new Specialization()
            {
                Id = 2,
                Name = "Невролог",
                //Medic = medicTwo,
                MedicId = medicTwo.Id
            };
            Specialization specializationThree = new Specialization()
            {
                Id = 3,
                Name = "Терапевт",
                //Medic = medicTwo,
                MedicId = medicTwo.Id
            };
            Specialization specializationFour = new Specialization()
            {
                Id = 4,
                Name = "Кардиолог",
                //Medic = medicThree,
                MedicId = medicThree.Id
            };
            Specialization specializationFive = new Specialization()
            {
                Id = 5,
                Name = "Психотерапевт",
                //Medic = medicThree,
                MedicId = medicThree.Id
            };
            #endregion

            modelBuilder.Entity<City>().HasKey(c => c.Id);
            modelBuilder.Entity<Polyclinic>().HasKey(c => c.Id);
            modelBuilder.Entity<Medic>().HasKey(c => c.Id);
            modelBuilder.Entity<Specialization>().HasKey(c => c.Id);

            modelBuilder.Entity<City>().HasData(cityOne, cityTwo, cityThree, cityFour, cityFive);
            modelBuilder.Entity<Polyclinic>().HasData(polyclinicOne, polyclinicTwo, polyclinicThree);
            modelBuilder.Entity<Medic>().HasData(medicOne, medicTwo, medicThree);
            modelBuilder.Entity<Specialization>().HasData(specializationOne, specializationTwo, specializationThree, specializationFour, specializationFive);
        }
    }
}

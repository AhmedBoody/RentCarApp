using System;
using System.Collections.Generic;
using RentCarApp.Domain.Cars.ValueObjects;
using RentCarApp.Domain.Cities.Rules;
using RentCarApp.Domain.Manufacturers;
using RentCarApp.Domain.SeedWork;
using RentCarApp.Domain.SharedKernel;

namespace RentCarApp.Domain.Cities
{
    public class Car : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public PlateNumberValue PlateNumber { get; private set; }
        public ModelYearValue ModelYear { get; private set; }
        public MoneyValue DailyRent { get; private set; }
        public MoneyValue WeeklyRent { get; private set; }
        public Guid CarModelId { get; private set; }
        public Guid CarTypelId { get; private set; }
        public List<CarFeature> CarFeatures { get; private set; }

        public Car()
        {
            //Only For EF.
        }
        private Car(Guid id, MoneyValue dailyRate, MoneyValue weeklyRate, Guid carModelId, Guid carTypeId, ModelYearValue modelYear, PlateNumberValue plateNumber)
        {
            this.Id = id;
            this.DailyRent = dailyRate;
            this.WeeklyRent = weeklyRate;
            this.ModelYear = modelYear;
            this.PlateNumber = plateNumber;
            this.CarTypelId = carTypeId;
            this.CarModelId = carModelId;
        }

        public static Car CreateCar(Guid id,
            string currency,
            decimal dailyRent,
            decimal weeklyRent,
            int modelYear,
            string plateNumber,
            Guid carModelId,
            Guid carTypeId)
        {
            return new Car(id,
                 MoneyValue.Of(dailyRent, currency),
                  MoneyValue.Of(weeklyRent, currency),
                  carModelId,
                  carTypeId,
                  ModelYearValue.Of(modelYear),
                  PlateNumberValue.Of(plateNumber,id.ToString()));
        }

    }
}

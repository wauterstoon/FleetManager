﻿using FleetManagement.Business.Entities;
using FleetManagement.Business.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FleetManagement.Business.Entities.Tests
{
    public class VehicleTests
    {
        
        [Fact]
        public void Test_Constructor_Valid()
        {
            Driver driver = new Driver("Elvis", "Presley", new DateTime(1997, 05, 20), "97.05.20-327.78", new List<string> { "B", "A1" });
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, driver);
            Assert.Equal(1, vehicle.VehicleId);
            Assert.Equal("Porsche", vehicle.Brand);
            Assert.Equal("GT2RS", vehicle.Model);
            Assert.Equal("1234-1234-1234-17", vehicle.ChassisNumber);
            Assert.Equal("KAPPER FURKAN", vehicle.LicensePlate);
            Assert.Equal("Gasoline", vehicle.FuelType);
            Assert.Equal("Sportauto", vehicle.VehicleType);
            Assert.Equal("Donkergrijs", vehicle.Color);
            Assert.Equal(2, vehicle.Doors);
            Assert.Equal(driver, vehicle.Driver);
        }

        [Fact]
        public void Test_SetVehicleId_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetVehicleId(1);
            Assert.Equal(1, vehicle.VehicleId);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Test_SetVehicleId_Invalid(int id)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetVehicleId(id));
        }

        [Fact]
        public void Test_SetBrand_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetBrand("BMW");
            Assert.Equal("BMW", vehicle.Brand);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetBrand_Invalid(string brand)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetBrand(brand));
        }

        [Fact]
        public void Test_SetModel_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetModel("M5");
            Assert.Equal("M5", vehicle.Model);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetModel_Invalid(string model)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetModel(model));
        }

        [Fact]
        public void Test_SetChassisNumber_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetChassisNumber("4444-4444-4444-17");
            Assert.Equal("4444-4444-4444-17", vehicle.ChassisNumber);
        }

        [Theory]
        [InlineData("")]
        [InlineData("4444-4444-4444-18-")]
        [InlineData(null)]
        public void Test_SetChassisNumber_Invalid(string chassisNumber)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetChassisNumber(chassisNumber));
        }

        [Fact]
        public void Test_SetLicensePlate_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetLicensePlate("KAPPER IMRE");
            Assert.Equal("KAPPER IMRE", vehicle.LicensePlate);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        //[InlineData("ehtfkljagryvrayevgtgburykotuklhilmh9olohl;0")]  license plate max characters ?
        public void Test_SetLicensePlate_Invalid(string plate)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetLicensePlate(plate));
        }

        [Fact]
        public void Test_SetFuelType_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetFuelType("Benzine");
            Assert.Equal("Benzine", vehicle.FuelType);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Test_SetFuelType_Invalid(string fuelType)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetFuelType(fuelType));
        }

        [Fact]
        public void Test_SetVehicleType_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetVehicleType("personenwagen");
            Assert.Equal("personenwagen", vehicle.VehicleType);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetVehicleType_Invalid(string type)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetVehicleType(type));
        }

        [Fact]
        public void Test_SetVehicleColor_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetVehicleColor("Red");
            Assert.Equal("Red", vehicle.Color);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_SetVehicleColor_Invalid(string color)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetVehicleColor(color));
        }

        [Fact]
        public void Test_SetVehicleDoors_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            vehicle.SetVehicleDoors(2);
            Assert.Equal(2, vehicle.Doors);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(8)]
        [InlineData(27)]
        public void Test_SetVehicleDoors_Invalid(int doors)
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Assert.Throws<VehicleException>(() => vehicle.SetVehicleDoors(doors));
        }

        [Fact]
        public void Test_SetDriver_Valid()
        {
            Vehicle vehicle = new Vehicle(1, "Porsche", "GT2RS", "1234-1234-1234-17", "KAPPER FURKAN", "Gasoline", "Sportauto", "Donkergrijs", 2, null);
            Driver driver = new Driver("Elvis", "Presley", new DateTime(1997, 05, 20), "97.05.20-327.78", new List<string> { "B", "A1" });
            vehicle.SetDriver(driver);
            Assert.Equal(driver, vehicle.Driver);
        }

        //TODO Test_SetDriver_Invalid()

    }
}
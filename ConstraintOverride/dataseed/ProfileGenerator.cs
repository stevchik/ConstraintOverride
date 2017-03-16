using ConstraintOverride.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstraintOverride.dto.Constraints;

namespace ConstraintOverride.dataseed
{
    public class ProfileGenerator
    {
        public static Profile GetProfile()
        {
            Profile profile = new Profile();
            profile.RouteConstraints = new List<RouteConstraint>() { new RouteConstraint() {  OutOfRoute = 100, Mode =  "TL"},
                                                                    new RouteConstraint() {  OutOfRoute = 1000, Mode =  "IMDL"}};

            profile.EquipmentTypeConstraints = new List<EquipmentTypeConstraint>() { new EquipmentTypeConstraint() { EquipmentType="53", MaximumWeight=10000, MinimumPallets=5} };

            profile.Overrides = GetOverrides();

            return profile;
        }

        private static List<Override> GetOverrides()
        {
            List<Override> overrides = new List<Override>();

            overrides.Add(GetSingleFilterSingleOverride());
            overrides.Add(GetMultipleFiltersWithSingleOverride());
            overrides.Add(GetCustomerAndWarehouseFilterSingleOverride());
            return overrides;
        }

        /// <summary>
        /// Create an override for C1 and Warehouse either W10 or W20. Out of Route will be 500
        /// </summary>
        /// <returns></returns>
        private static Override GetCustomerAndWarehouseFilterSingleOverride()
        {
            Override custom1 = new Override();
            Filter filter1 = new Filter();

            PropertyValue customerC1 = new PropertyValue();
            PropertyValue warehouse10and20 = new PropertyValue();

            PropertyValue override1 = new PropertyValue();

            custom1.Name = "C1 customer with either W10 or W20 and single condition";
            custom1.Filters = new List<Filter>() { filter1 };
            custom1.ConstraintOverrides = new List<PropertyValue>() { override1 };

            filter1.Name = "Customer is C1 and Warehouse is W10 or W20";
            filter1.FilterConditions = new List<PropertyValue>() { customerC1, warehouse10and20 };
            filter1.Priority = 1;

            customerC1.PropertyName = "CustomerCode";
            customerC1.PropertyMap = "Orders.CustomerCode";
            customerC1.Value = "C1";
            customerC1.Operator = FilterOperator.Equals;

            warehouse10and20.PropertyName = "WarehouseCode";
            warehouse10and20.PropertyMap = "Stops.Warehouse.WarehouseCode";
            warehouse10and20.Value = "W10,W20";
            warehouse10and20.Operator = FilterOperator.Contains;

            override1.PropertyName = "OutOfRoute";
            override1.PropertyMap = "Profile.RouteConstraint.OutOfRoute";
            override1.Value = 500;

            return custom1;
        }

        /// <summary>
        /// Create an ovveride for T200. OutOfRoute will be 200
        /// </summary>
        /// <returns></returns>
        private static Override GetSingleFilterSingleOverride()
        {
            Override custom1 = new Override();
            Filter filter1 = new Filter();

            PropertyValue carrierT1 = new PropertyValue();
            PropertyValue override1 = new PropertyValue();

            custom1.Name = "Single filter with single condition";
            custom1.Filters = new List<Filter>() { filter1 };
            custom1.ConstraintOverrides = new List<PropertyValue>() { override1 };

            filter1.Name = "Carrier is T2";
            filter1.FilterConditions = new List<PropertyValue>() { carrierT1 };
            filter1.Priority = 3;

            carrierT1.PropertyName = "CarrierCode";
            carrierT1.PropertyMap = "Carrier.CarrierCode";
            carrierT1.Value = "T2";
            carrierT1.Operator = FilterOperator.Equals;

            override1.PropertyName = "OutOfRoute";
            override1.PropertyMap = "Profile.RouteConstraint.OutOfRoute";
            override1.Value = 200;

            return custom1;
        }

        /// <summary>
        /// Create an override for T3 and Mode = TL and IsTeam = false. Override will be 300
        /// </summary>
        /// <returns></returns>
        private static Override GetMultipleFiltersWithSingleOverride()
        {
            Override custom2 = new Override();
            Filter filter1 = new Filter();

            PropertyValue carrierT3 = new PropertyValue();
            PropertyValue modeTL = new PropertyValue();
            PropertyValue driver1 = new PropertyValue();

            PropertyValue override1 = new PropertyValue();

            custom2.Name = "Carrier is T3 and mode is 'TL' and Driver is one with single override condition";
            custom2.Filters = new List<Filter>() { filter1 };
            custom2.ConstraintOverrides = new List<PropertyValue>() { override1 };

            filter1.Name = "Carrier is T3 and mode is 'TL' and Driver is one";
            filter1.FilterConditions = new List<PropertyValue>() { carrierT3, modeTL, driver1 };
            filter1.Priority = 2;

            carrierT3.PropertyName = "CarrierCode";
            carrierT3.PropertyMap = "Carrier.CarrierCode";
            carrierT3.Value = "T3";
            carrierT3.Operator = FilterOperator.Equals;

            modeTL.PropertyName = "Mode";
            modeTL.PropertyMap = "Mode";
            modeTL.Value = "TL";
            modeTL.Operator = FilterOperator.Equals;

            driver1.PropertyName = "IsTeam";
            driver1.PropertyMap = "DriverType.IsTeam";
            driver1.Value = false;
            driver1.Operator = FilterOperator.Equals;

            override1.PropertyName = "OutOfRoute";
            override1.PropertyMap = "Profile.RouteConstraint.OutOfRoute";
            override1.Value = 300;

            return custom2;
        }
    }
}

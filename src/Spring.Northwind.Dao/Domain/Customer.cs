#region License

/*
 * Copyright 2002-2007 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Spring.Northwind.Domain
{
    /// <summary>
    /// Customer entity. We 
    /// </summary>
    public class Customer
    {
        #region Fields

        protected string id;
        protected string companyName;
        protected string contactName;
        protected string contactTitle;
        protected string address;
        protected string city;
        protected string region;
        protected string postalCode;
        protected string country;
        protected string phone;
        protected string fax;
        protected IList<Order> orders;

        // our calculator that is injected by Spring
        private readonly ICustomerClassificationCalculator calculator;
        
        #endregion

        #region Properties

        public virtual string Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public virtual string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        public virtual string ContactTitle
        {
            get { return contactTitle; }
            set { contactTitle = value; }
        }

        public virtual string Address
        {
            get { return address; }
            set { address = value; }
        }

        public virtual string City
        {
            get { return city; }
            set { city = value; }
        }

        public virtual string Region
        {
            get { return region; }
            set { region = value; }
        }

        public virtual string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public virtual string Country
        {
            get { return country; }
            set { country = value; }
        }

        public virtual string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public virtual string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public virtual IList<Order> Orders
        {
            get
            {
                return new List<Order>(orders ?? new List<Order>(0));
            }
        }

        public virtual string Classification
        {
            get { return calculator.CalculateClassification(this);  }
        }

        #endregion

        #region Constructor (s)

        public Customer(){ }

        public Customer(ICustomerClassificationCalculator calculator)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException("calculator", "Calculator cannot be null");
            }
            this.calculator = calculator;
        }

        public Customer(string companyName, string contactName, string contactTitle, string address, string city,
                        string region, string postalCode, string country, string phone, string fax)
        {
            this.companyName = companyName;
            this.contactName = contactName;
            this.contactTitle = contactTitle;
            this.address = address;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.country = country;
            this.phone = phone;
            this.fax = fax;
        }

        #endregion
    }
}
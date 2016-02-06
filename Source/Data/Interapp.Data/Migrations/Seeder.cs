﻿using Interapp.Data.Models;
using System.Collections.Generic;

namespace Interapp.Data.Migrations
{
    public class Seeder
    {
        public Seeder()
        {
            this.Countries = new HashSet<Country>();
            this.GenerateCountries();
        }

        public ICollection<Country> Countries { get; set; }

        private void GenerateCountries()
        {
            this.Countries.Add(new Country() { Name = "Afghanistan" });
            this.Countries.Add(new Country() { Name = "Albania" });
            this.Countries.Add(new Country() { Name = "Algeria" });
            this.Countries.Add(new Country() { Name = "Andorra" });
            this.Countries.Add(new Country() { Name = "Angola" });
            this.Countries.Add(new Country() { Name = "Antigua and Barbuda" });
            this.Countries.Add(new Country() { Name = "Argentina" });
            this.Countries.Add(new Country() { Name = "Armenia" });
            this.Countries.Add(new Country() { Name = "Aruba" });
            this.Countries.Add(new Country() { Name = "Australia" });
            this.Countries.Add(new Country() { Name = "Austria" });
            this.Countries.Add(new Country() { Name = "Azerbaijan" });
            this.Countries.Add(new Country() { Name = "Bahamas" });
            this.Countries.Add(new Country() { Name = "Bahrain" });
            this.Countries.Add(new Country() { Name = "Bangladesh" });
            this.Countries.Add(new Country() { Name = "Barbados" });
            this.Countries.Add(new Country() { Name = "Belarus" });
            this.Countries.Add(new Country() { Name = "Belgium" });
            this.Countries.Add(new Country() { Name = "Belize" });
            this.Countries.Add(new Country() { Name = "Benin" });
            this.Countries.Add(new Country() { Name = "Bhutan" });
            this.Countries.Add(new Country() { Name = "Bolivia" });
            this.Countries.Add(new Country() { Name = "Bosnia and Herzegovina" });
            this.Countries.Add(new Country() { Name = "Botswana" });
            this.Countries.Add(new Country() { Name = "Brazil" });
            this.Countries.Add(new Country() { Name = "Brunei" });
            this.Countries.Add(new Country() { Name = "Bulgaria" });
            this.Countries.Add(new Country() { Name = "Burkina Faso" });
            this.Countries.Add(new Country() { Name = "Burma" });
            this.Countries.Add(new Country() { Name = "Burundi" });
            this.Countries.Add(new Country() { Name = "Cambodia" });
            this.Countries.Add(new Country() { Name = "Cameroon" });
            this.Countries.Add(new Country() { Name = "Canada" });
            this.Countries.Add(new Country() { Name = "Cape Verde" });
            this.Countries.Add(new Country() { Name = "Central African Republic" });
            this.Countries.Add(new Country() { Name = "Chad" });
            this.Countries.Add(new Country() { Name = "Chile" });
            this.Countries.Add(new Country() { Name = "China" });
            this.Countries.Add(new Country() { Name = "Colombia" });
            this.Countries.Add(new Country() { Name = "Comoros" });
            this.Countries.Add(new Country() { Name = "Costa Rica" });
            this.Countries.Add(new Country() { Name = "Cote d'Ivoire" });
            this.Countries.Add(new Country() { Name = "Croatia" });
            this.Countries.Add(new Country() { Name = "Cuba" });
            this.Countries.Add(new Country() { Name = "Curacao" });
            this.Countries.Add(new Country() { Name = "Cyprus" });
            this.Countries.Add(new Country() { Name = "Czech Republic" });
            this.Countries.Add(new Country() { Name = "Denmark" });
            this.Countries.Add(new Country() { Name = "Djibouti" });
            this.Countries.Add(new Country() { Name = "Dominica" });
            this.Countries.Add(new Country() { Name = "Dominican Republic" });
            this.Countries.Add(new Country() { Name = "East Timor" });
            this.Countries.Add(new Country() { Name = "Ecuador" });
            this.Countries.Add(new Country() { Name = "Egypt" });
            this.Countries.Add(new Country() { Name = "El Salvador" });
            this.Countries.Add(new Country() { Name = "Equatorial Guinea" });
            this.Countries.Add(new Country() { Name = "Eritrea" });
            this.Countries.Add(new Country() { Name = "Estonia" });
            this.Countries.Add(new Country() { Name = "Ethiopia" });
            this.Countries.Add(new Country() { Name = "Fiji" });
            this.Countries.Add(new Country() { Name = "Finland" });
            this.Countries.Add(new Country() { Name = "France" });
            this.Countries.Add(new Country() { Name = "Gabon" });
            this.Countries.Add(new Country() { Name = "Gambia" });
            this.Countries.Add(new Country() { Name = "Georgia" });
            this.Countries.Add(new Country() { Name = "Germany" });
            this.Countries.Add(new Country() { Name = "Ghana" });
            this.Countries.Add(new Country() { Name = "Greece" });
            this.Countries.Add(new Country() { Name = "Grenada" });
            this.Countries.Add(new Country() { Name = "Guatemala" });
            this.Countries.Add(new Country() { Name = "Guinea" });
            this.Countries.Add(new Country() { Name = "Guinea-Bissau" });
            this.Countries.Add(new Country() { Name = "Guyana" });
            this.Countries.Add(new Country() { Name = "Haiti" });
            this.Countries.Add(new Country() { Name = "Holy See" });
            this.Countries.Add(new Country() { Name = "Honduras" });
            this.Countries.Add(new Country() { Name = "Hong Kong" });
            this.Countries.Add(new Country() { Name = "Hungary" });
            this.Countries.Add(new Country() { Name = "Iceland" });
            this.Countries.Add(new Country() { Name = "India" });
            this.Countries.Add(new Country() { Name = "Indonesia" });
            this.Countries.Add(new Country() { Name = "Iran" });
            this.Countries.Add(new Country() { Name = "Iraq" });
            this.Countries.Add(new Country() { Name = "Ireland" });
            this.Countries.Add(new Country() { Name = "Israel" });
            this.Countries.Add(new Country() { Name = "Italy" });
            this.Countries.Add(new Country() { Name = "Jamaica" });
            this.Countries.Add(new Country() { Name = "Japan" });
            this.Countries.Add(new Country() { Name = "Jordan" });
            this.Countries.Add(new Country() { Name = "Kazakhstan" });
            this.Countries.Add(new Country() { Name = "Kenya" });
            this.Countries.Add(new Country() { Name = "Kiribati" });
            this.Countries.Add(new Country() { Name = "North Korea" });
            this.Countries.Add(new Country() { Name = "South Korea" });
            this.Countries.Add(new Country() { Name = "Kosovo" });
            this.Countries.Add(new Country() { Name = "Kuwait" });
            this.Countries.Add(new Country() { Name = "Kyrgyzstan" });
            this.Countries.Add(new Country() { Name = "Laos" });
            this.Countries.Add(new Country() { Name = "Latvia" });
            this.Countries.Add(new Country() { Name = "Lebanon" });
            this.Countries.Add(new Country() { Name = "Lesotho" });
            this.Countries.Add(new Country() { Name = "Liberia" });
            this.Countries.Add(new Country() { Name = "Libya" });
            this.Countries.Add(new Country() { Name = "Liechtenstein" });
            this.Countries.Add(new Country() { Name = "Lithuania" });
            this.Countries.Add(new Country() { Name = "Luxembourg" });
            this.Countries.Add(new Country() { Name = "Macau" });
            this.Countries.Add(new Country() { Name = "Macedonia" });
            this.Countries.Add(new Country() { Name = "Madagascar" });
            this.Countries.Add(new Country() { Name = "Malawi" });
            this.Countries.Add(new Country() { Name = "Malaysia" });
            this.Countries.Add(new Country() { Name = "Maldives" });
            this.Countries.Add(new Country() { Name = "Mali" });
            this.Countries.Add(new Country() { Name = "Malta" });
            this.Countries.Add(new Country() { Name = "Marshall Islands" });
            this.Countries.Add(new Country() { Name = "Mauritania" });
            this.Countries.Add(new Country() { Name = "Mauritius" });
            this.Countries.Add(new Country() { Name = "Mexico" });
            this.Countries.Add(new Country() { Name = "Micronesia" });
            this.Countries.Add(new Country() { Name = "Moldova" });
            this.Countries.Add(new Country() { Name = "Monaco" });
            this.Countries.Add(new Country() { Name = "Mongolia" });
            this.Countries.Add(new Country() { Name = "Montenegro" });
            this.Countries.Add(new Country() { Name = "Morocco" });
            this.Countries.Add(new Country() { Name = "Mozambique" });
            this.Countries.Add(new Country() { Name = "Namibia" });
            this.Countries.Add(new Country() { Name = "Nauru" });
            this.Countries.Add(new Country() { Name = "Nepal" });
            this.Countries.Add(new Country() { Name = "Netherlands" });
            this.Countries.Add(new Country() { Name = "Netherlands Antilles" });
            this.Countries.Add(new Country() { Name = "New Zealand" });
            this.Countries.Add(new Country() { Name = "Nicaragua" });
            this.Countries.Add(new Country() { Name = "Niger" });
            this.Countries.Add(new Country() { Name = "Nigeria" });
            this.Countries.Add(new Country() { Name = "Norway" });
            this.Countries.Add(new Country() { Name = "Oman" });
            this.Countries.Add(new Country() { Name = "Pakistan" });
            this.Countries.Add(new Country() { Name = "Palau" });
            this.Countries.Add(new Country() { Name = "Palestinian Territories" });
            this.Countries.Add(new Country() { Name = "Panama" });
            this.Countries.Add(new Country() { Name = "Papua New Guinea" });
            this.Countries.Add(new Country() { Name = "Paraguay" });
            this.Countries.Add(new Country() { Name = "Peru" });
            this.Countries.Add(new Country() { Name = "Philippines" });
            this.Countries.Add(new Country() { Name = "Poland" });
            this.Countries.Add(new Country() { Name = "Portugal" });
            this.Countries.Add(new Country() { Name = "Qatar" });
            this.Countries.Add(new Country() { Name = "Romania" });
            this.Countries.Add(new Country() { Name = "Russia" });
            this.Countries.Add(new Country() { Name = "Rwanda" });
            this.Countries.Add(new Country() { Name = "Saint Kitts and Nevis" });
            this.Countries.Add(new Country() { Name = "Saint Lucia" });
            this.Countries.Add(new Country() { Name = "Saint Vincent and the Grenadines" });
            this.Countries.Add(new Country() { Name = "Samoa" });
            this.Countries.Add(new Country() { Name = "San Marino" });
            this.Countries.Add(new Country() { Name = "Sao Tome and Principe" });
            this.Countries.Add(new Country() { Name = "Saudi Arabia" });
            this.Countries.Add(new Country() { Name = "Senegal" });
            this.Countries.Add(new Country() { Name = "Serbia" });
            this.Countries.Add(new Country() { Name = "Seychelles" });
            this.Countries.Add(new Country() { Name = "Sierra Leone" });
            this.Countries.Add(new Country() { Name = "Singapore" });
            this.Countries.Add(new Country() { Name = "Sint Maarten" });
            this.Countries.Add(new Country() { Name = "Slovakia" });
            this.Countries.Add(new Country() { Name = "Slovenia" });
            this.Countries.Add(new Country() { Name = "Solomon Islands" });
            this.Countries.Add(new Country() { Name = "Somalia" });
            this.Countries.Add(new Country() { Name = "South Africa" });
            this.Countries.Add(new Country() { Name = "South Sudan" });
            this.Countries.Add(new Country() { Name = "Spain" });
            this.Countries.Add(new Country() { Name = "Sri Lanka" });
            this.Countries.Add(new Country() { Name = "Sudan" });
            this.Countries.Add(new Country() { Name = "Suriname" });
            this.Countries.Add(new Country() { Name = "Swaziland" });
            this.Countries.Add(new Country() { Name = "Sweden" });
            this.Countries.Add(new Country() { Name = "Switzerland" });
            this.Countries.Add(new Country() { Name = "Syria" });
            this.Countries.Add(new Country() { Name = "Taiwan" });
            this.Countries.Add(new Country() { Name = "Tajikistan" });
            this.Countries.Add(new Country() { Name = "Tanzania" });
            this.Countries.Add(new Country() { Name = "Thailand" });
            this.Countries.Add(new Country() { Name = "Timor-Leste" });
            this.Countries.Add(new Country() { Name = "Togo" });
            this.Countries.Add(new Country() { Name = "Tonga" });
            this.Countries.Add(new Country() { Name = "Trinidad and Tobago" });
            this.Countries.Add(new Country() { Name = "Tunisia" });
            this.Countries.Add(new Country() { Name = "Turkey" });
            this.Countries.Add(new Country() { Name = "Turkmenistan" });
            this.Countries.Add(new Country() { Name = "Tuvalu" });
            this.Countries.Add(new Country() { Name = "Uganda" });
            this.Countries.Add(new Country() { Name = "Ukraine" });
            this.Countries.Add(new Country() { Name = "United Arab Emirates" });
            this.Countries.Add(new Country() { Name = "United Kingdom" });
            this.Countries.Add(new Country() { Name = "Uruguay" });
            this.Countries.Add(new Country() { Name = "Uzbekistan" });
            this.Countries.Add(new Country() { Name = "Vanuatu" });
            this.Countries.Add(new Country() { Name = "Venezuela" });
            this.Countries.Add(new Country() { Name = "Vietnam" });
            this.Countries.Add(new Country() { Name = "Yemen" });
            this.Countries.Add(new Country() { Name = "Zambia" });
            this.Countries.Add(new Country() { Name = "Zimbabwe" });
        }
    }
}
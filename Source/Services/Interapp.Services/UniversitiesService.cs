namespace Interapp.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common;
    using Contracts;
    using Data.Common;
    using Data.Models;
    using Interapp.Common.Enums;

    public class UniversitiesService : IUniversitiesService
    {
        private IDbRepository<University> universities;

        public UniversitiesService(IDbRepository<University> universities)
        {
            this.universities = universities;
        }

        public IQueryable<University> All()
        {
            return this.universities.All();
        }

        public void Create(string directorId, string name, int tuitionFee, int countryId)
        {
            var university = new University()
            {
                CountryId = countryId,
                DirectorId = directorId,
                Name = name,
                TuitionFee = tuitionFee,
                CreatedOn = DateTime.UtcNow
            };

            this.universities.Add(university);
            this.universities.Save();
        }

        public void Delete(int id)
        {
            var university = this.universities.GetById(id);
            this.universities.Delete(university);
            this.universities.Save();
        }

        public University GetById(int id)
        {
            return this.universities.All()
                .Where(u => u.Id == id)
                .Include(u => u.Director)
                .Include(u => u.Country)
                .Include(u => u.Students)
                .Include(u => u.InterestedStudents)
                .Include(u => u.DocumentRequirements)
                .FirstOrDefault();
        }

        public IQueryable<University> GetFiltered(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public void Update(University university)
        {
            var orgUniversity = this.universities
                .All()
                .Where(u => u.Id == university.Id)
                .FirstOrDefault();

            if (orgUniversity != null)
            {
                orgUniversity.Name = university.Name;
                orgUniversity.RequiredCambridgeLevel = university.RequiredCambridgeLevel;
                orgUniversity.RequiredCambridgeScore = university.RequiredCambridgeScore;
                orgUniversity.RequiredIBTToefl = university.RequiredIBTToefl;
                orgUniversity.RequiredPBTToefl = university.RequiredPBTToefl;
                orgUniversity.RequiredSAT = university.RequiredSAT;
                orgUniversity.TuitionFee = university.TuitionFee;

                this.universities.Save();
            }
        }

        public IQueryable<University> FilterUniversities(IQueryable<University> universities, FilterModel filter)
        {
            if (universities == null)
            {
                return universities;
            }

            universities = universities.OrderBy(u => u.Name);

            if (filter != null)
            {
                if (filter.Filter != null)
                {
                    universities = universities.Where(u => u.Name.Contains(filter.Filter));
                }

                if (filter.OrderBy != null)
                {
                    if (filter.Order == "asc")
                    {
                        if (filter.OrderBy == "name")
                        {
                            universities = universities.OrderBy(u => u.Name);
                        }
                        else if (filter.OrderBy == "country")
                        {
                            universities = universities.OrderBy(u => u.Country.Name);
                        }
                        else if (filter.OrderBy == "tuition")
                        {
                            universities = universities.OrderBy(u => u.TuitionFee);
                        }
                        else if (filter.OrderBy == "sat")
                        {
                            universities = universities.OrderBy(u => u.RequiredSAT);
                        }
                        else if (filter.OrderBy == "toeflpbt")
                        {
                            universities = universities.OrderBy(u => u.RequiredPBTToefl);
                        }
                        else if (filter.OrderBy == "toeflibt")
                        {
                            universities = universities.OrderBy(u => u.RequiredIBTToefl);
                        }
                    }
                    else
                    {
                        if (filter.OrderBy == "name")
                        {
                            universities = universities.OrderByDescending(u => u.Name);
                        }
                        else if (filter.OrderBy == "country")
                        {
                            universities = universities.OrderByDescending(u => u.Country);
                        }
                        else if (filter.OrderBy == "tuition")
                        {
                            universities = universities.OrderByDescending(u => u.TuitionFee);
                        }
                        else if (filter.OrderBy == "sat")
                        {
                            universities = universities.OrderByDescending(u => u.RequiredSAT);
                        }
                        else if (filter.OrderBy == "toeflpbt")
                        {
                            universities = universities.OrderByDescending(u => u.RequiredPBTToefl);
                        }
                        else if (filter.OrderBy == "toeflibt")
                        {
                            universities = universities.OrderByDescending(u => u.RequiredIBTToefl);
                        }
                    }
                }
            }

            return universities;
        }

        public IQueryable<University> AllWithDirectorAndCountry()
        {
            return this.universities
                .All()
                .Include(u => u.Country)
                .Include(u => u.Director)
                .Include(u => u.Director.Director);
        }

        public IQueryable<University> AllWithCountry()
        {
            return this.universities
                .All()
                .Include(u => u.Country);
        }

        public University GetByIdWithDocuments(int id)
        {
            return this.universities
                .All()
                .Where(u => u.Id == id)
                .Include(u => u.DocumentRequirements)
                .FirstOrDefault();
        }

        public IQueryable<University> AllForStudent(string studentId)
        {
            return this.universities
                .All()
                .Where(u => u.InterestedStudents
                    .Any(s => s.StudentId == studentId))
                .Include(u => u.Country);
        }
    }
}

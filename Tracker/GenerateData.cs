namespace Tracker
{
    using System;
    using System.Collections.Generic;

    public class GenerateData
    {
        public Candidate GenerateCandidate()
        {
            return new Candidate { Name = "abc", YearsOfWorkExperience = 2 };
        }

        public Consultancy GenerateConsultancy()
        {
            return new Consultancy { Name = "Consultancy1" };
        }

        public Interview GenerateInterview()
        {
            return new Interview { Date = DateTime.Now };
        }

        public Interviewer GenerateInterviewer()
        {
            return new Interviewer { Name = "Interviewer1" };
        }

        public Result GenerateResult()
        {
            return Result.Selected("");
        }

        public Round GenerateRound()
        {
            return Round.CaseStudy;
        }

        public Vacancy GenerateVacancy()
        {
            return new Vacancy
            {
                MinimumYearsOfWorkExperience = 2,
                ResponsibilitiesDescription = "testing"
            };
        }

        public List<Candidate> GenerateListOfCandidates()
        {
            return new List<Candidate>
            {
                new Candidate { Name = "abc", YearsOfWorkExperience = 2 },
                new Candidate { Name = "Candidate2", YearsOfWorkExperience = 1}
            };
        }

        public List<Consultancy> GenerateListOfConsultancy()
        {
            return new List<Consultancy>
            {
                new Consultancy { Name = "Consultancy1" }, new Consultancy { Name = "Armour" }
            };
        }

        public List<Interview> GenerateListOfInterview()
        {
            return new List<Interview>{new  Interview { Date = DateTime.Now },
                new Interview {Date = DateTime.Today.Subtract(TimeSpan.FromDays(2))} };
        }

        public List<Interviewer> GenerateListOfInterviewer()
        {
            return new List<Interviewer>
            {
                new Interviewer { Name = "Interviewer1" },new Interviewer { Name = "RAKE" }, new Interviewer { Name = "RANJ" }, new Interviewer { Name = "RSIN" }
            };
        }


        public List<Result> GenerateListOfResult()
        {
            return new List<Result>
            {
                Result.Selected(""), Result.Rejected("")
            };
        }

        public List<Round> GenerateListOfRound()
        {
            return new List<Round>
            {
                Round.CaseStudy,Round.Telephonic
            };
        }


        public List<Vacancy> GenerateListOfVacancy()
        {
            return new List<Vacancy>{
                new Vacancy{MinimumYearsOfWorkExperience = 2,ResponsibilitiesDescription = "testing"},
                new Vacancy{MinimumYearsOfWorkExperience = 3,ResponsibilitiesDescription = "testing"},
            };
        }
    }
}

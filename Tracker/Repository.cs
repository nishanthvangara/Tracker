namespace Tracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    interface IRepository<T>
    {
        List<T> GetAll();
    }

    // GetAll, Add, Remove, Update
    public class VacancyRepo : IRepository<Vacancy>
    {
        public List<Vacancy> MemoryList = new List<Vacancy>();

        public List<Vacancy> GetAll()
        {
            return MemoryList;
        }

        public void Add(int minYearsOfExp, string responsibilities)
        {
            Vacancy newVacancy = new Vacancy
            {
                MinimumYearsOfWorkExperience = minYearsOfExp,
                ResponsibilitiesDescription = responsibilities
            };
            MemoryList.Add(newVacancy);
        }

        public void Remove(string responsibilities)
        {
            foreach (Vacancy item in MemoryList)
            {
                if (item.ResponsibilitiesDescription == responsibilities)
                    MemoryList.Remove(item);
            }
        }

        public void Update(Vacancy changedVacancy, int newExperience, string newResponsibilities)
        {
            changedVacancy.ResponsibilitiesDescription = newResponsibilities;
            changedVacancy.MinimumYearsOfWorkExperience = newExperience;
        }

        public bool CheckIfVacancyExists(string name)
        {
            return MemoryList.Any(item => item.ResponsibilitiesDescription == name);
        }
    }

    // GetAll
    public class SkillSetRepo : IRepository<SkillSet>
    {
        SkillSet _skillSet = new SkillSet();
        private SkillRepo _skillRepository = new SkillRepo();
        private SkillLevelRepo _skillLevelRepository = new SkillLevelRepo();

        public List<SkillSet> GetAll()
        {
            var skillList = _skillRepository.GetAll();
            var skillLevelList = _skillLevelRepository.GetAll();
            _skillSet.Skills.Add(Tuple.Create(new Skill { Name = "" }, SkillLevel.Advanced));
            return null;
        }
    }
    // GetAll
    public class SkillLevelRepo : IRepository<SkillLevel>
    {
        public List<SkillLevel> GetAll()
        {
            return new List<SkillLevel>
            {
               SkillLevel.Advanced,SkillLevel.Basic,SkillLevel.Functional
            };
        }
    }

    // GetAll, Add, Remove, Update, check
    public class SkillRepo : IRepository<Skill>
    {
        public List<Skill> MemoryList = new List<Skill>();

        public List<Skill> GetAll()
        {
            return MemoryList;
        }

        public void Add(string newSkill)
        {
            MemoryList.Add(new Skill { Name = newSkill });
        }

        public void Remove(string skill)
        {
            for (int i = 0; i < MemoryList.Count; i++)
            {
                if (MemoryList[i].Name == skill)
                    MemoryList.RemoveAt(i);
            }
        }

        public void Update(Skill changedSkill, string newSkill)
        {
            changedSkill.Name = newSkill;
        }

        public bool CheckIfSkillExists(string name)
        {
            return MemoryList.Any(item => item.Name == name);
        }
    }

    // GetAll, Add, Remove, Update, Check
    public class ConsultancyRepo : IRepository<Consultancy>
    {
        public List<Consultancy> GetAll()
        {
            using (var context = new MyContext())
            {
                var consultancyList = (from consultancy in context.Consultancies
                                  orderby consultancy.Name
                                  select consultancy).ToList();
                 return consultancyList;
            }
            
        }

        public void Add(string name)
        {
            var newConsultancy = new Consultancy {Name = name};

            using (var context = new MyContext())
            {
                context.Consultancies.Add(newConsultancy);
                context.SaveChanges();
            }
        }

        public void Remove(string consultancy)
        {
            using (var context = new MyContext())
            {
                
            }
        }

        public void Update(Consultancy changedConsultancy, string newName)
        {
            changedConsultancy.Name = newName;
        }

        //public bool CheckIfConsultancyExists(string name)
        //{
        //    return MemoryList.Any(item => item.Name == name);
        //}
    }

    // GetAll, Add, Remove, Update
    public class InterviewerRepo : IRepository<Interviewer>
    {
        public List<Interviewer> MemoryList = new List<Interviewer>();

        public List<Interviewer> GetAll()
        {
            return MemoryList;
        }


        public void Add(string interviewer)
        {
            MemoryList.Add(new Interviewer { Name = interviewer });
        }

        public void Remove(string interviewer)
        {
            foreach (Interviewer item in MemoryList)
            {
                if (item.Name == interviewer)
                    MemoryList.Remove(item);
            }
        }

        public void Update(Interviewer changedInterviewer, string newName)
        {
            changedInterviewer.Name = newName;
        }

        public bool CheckIfInterviewerExists(string name)
        {
            return MemoryList.Any(item => item.Name == name);
        }
    }

    // GetAll
    public class RoundRepo : IRepository<Round>
    {
        public List<Round> GetAll() =>
            new List<Round>
            {
                Round.Telephonic, Round.FaceToFace, Round.CaseStudy
            };
    }

    public class PanelRepo : IRepository<Panel>
    {
        public List<Panel> MemoryList = new List<Panel>();

        public List<Panel> GetAll()
        {
            MemoryList.Add(new Panel { PanelInterviewer = new Interviewer { Name = "" }, PanelRound = Round.FaceToFace });
            return MemoryList;
        }
    }

    // GetAll
    public class InterviewRepo : IRepository<Interview>
    {
        public List<Interview> MemoryList = new List<Interview>();
        ResultRepo resultRepo = new ResultRepo();
        PanelRepo PanelRepo = new PanelRepo();
        public List<Interview> GetAll() =>
    new List<Interview>
    {
                new Interview
                {
                    Date = DateTime.Now,
                    InterviewResult= resultRepo.MemoryList[1],
                    InterviewPanel =PanelRepo.MemoryList[0]
                }
    };
    }

    // GetAll, Add, Remove, Update, Check
    public class CandidateRepo : IRepository<Candidate>
    {
        #region SyncMethods

        public void Add(string name, int experience)
        {
            var newCandidate = new Candidate { Name = name, YearsOfWorkExperience = experience };
            using (var context = new MyContext())
            {
                context.Candidates.Add(newCandidate);
                var response = context.SaveChanges();
                // response == 0 -success
            }
        }

        public void Remove(string candidateName)
        {
            using (var context = new MyContext())
            {
                var removeCandidate = (from candidate in context.Candidates
                                       where candidate.Name == candidateName
                                       select candidate).Single();
                context.Candidates.Remove(removeCandidate);
                context.SaveChanges();
            }
        }

        public void Update(Candidate changedCandidate, string newName, int newExperience)
        {
            using (var context = new MyContext())
            {
                var updateCandidate = (from candidate in context.Candidates
                                       where candidate.Name == changedCandidate.Name
                                       select candidate).Single();
                updateCandidate.Name = newName;
                updateCandidate.YearsOfWorkExperience = newExperience;
                context.SaveChanges();
            }
        }

        public bool CheckIfCandidateExists(string name)
        {
            using (var context = new MyContext())
            {
                var searchCandidate = (from candidate in context.Candidates
                    where candidate.Name == name
                    select candidate).Single();
                if (searchCandidate!=null)
                    return true;
            }
            return false;
        }

        public List<Candidate> GetAll()
        {
            using (var context = new MyContext())
            {
                var candidates = (from candidate in context.Candidates
                                  orderby candidate.Name
                                  select candidate).ToList();
                return candidates;
            }
            
        }
        #endregion
    }

    //GetAll
    public class ResultRepo : IRepository<Result>
    {
        public List<Result> MemoryList = new List<Result>();

        public List<Result> GetAll() =>
            new List<Result>
            {
                Result.Selected(""), Result.Hold(""), Result.Recommended(""), Result.Rejected("")
            };
    }

    public class JourneyRepo //: IRepository<Journey>
    {
        public List<Journey> MemoryList = new List<Journey>();

        CandidateRepo CandidatesRepo = new CandidateRepo();
        InterviewRepo InterviewRepo = new InterviewRepo();
        Journey JourneyCandidate = new Journey();

        public List<Journey> GetAll()
        {
            var Candidates = CandidatesRepo.GetAll();
            var Interviewes = InterviewRepo.GetAll();
            //JourneyCandidate.JourneyOfCandidate = Tuple.Create(CandidatesRepo.MemoryList[0], InterviewRepo.MemoryList);
            MemoryList.Add(JourneyCandidate);
            return MemoryList;
        }
    }
}
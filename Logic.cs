//namespace Tracker
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Windows.Forms;
//    using System.Linq;

//    public class Logic
//    {

//        private CandidateRepo CandiadteRepository = new CandidateRepo();
//        private JourneyRepo JourneyRepository = new JourneyRepo();
//        private ConsultancyRepo ConsultancyRepository = new ConsultancyRepo();
//        private SkillRepo SkillRepository = new SkillRepo();
//        private InterviewRepo InterviewRepository = new InterviewRepo();

//        public void AddNewCandidate(string name, string cosultancyName, int yearsOfExperience, List<SkillSet> skillSet)
//        {
//            var newCandidate = CandidateCheck(name);
//            newCandidate.ConsultancyName = ConsultancyCheck(cosultancyName);
//            newCandidate.YearsOfWorkExperience = yearsOfExperience;
//            newCandidate.CandidateSkillSet = SkillSetCheck(skillSet);
//            CandiadteRepository.Add(newCandidate.Name, newCandidate.YearsOfWorkExperience);
//        }

//        private SkillSet SkillSetCheck(List<SkillSet> skillSet)
//        {
//            var newSkillSet = new SkillSet();
//            foreach (var item in skillSet)
//            {
//                SkillSetBreak(item);
//            }
//            return newSkillSet;
//        }

//        private void SkillSetBreak(SkillSet itemSkills)
//        {
//            SkillLevelCheck(itemSkills.Skills[0].Item2.ToString());
//            SkillCheck(itemSkills.Skills[0].Item1.ToString());
//        }

//        private SkillLevel SkillLevelCheck(string skillLevel)
//        {
//            if (skillLevel == SkillLevel.Advanced.ToString())
//            {
//                return SkillLevel.Advanced;
//            }
//            if (skillLevel == SkillLevel.Basic.ToString())
//            {
//                return SkillLevel.Basic;
//            }
//            if (skillLevel == SkillLevel.Functional.ToString())
//            {
//                return SkillLevel.Functional;
//            }
//            throw new Exception("Invalid SkillLevel");
//        }

//        private List<Skill> SkillCheck(string names)
//        {
//            List<Skill> checkedList = new List<Skill>();

//            var checkedInfo = SkillRepository.CheckIfSkillExists(names);
//            if (checkedInfo)
//            {
//                checkedList.Add(new Skill { Name = names });
//            }
//            else
//            {
//                SkillRepository.Add(names);
//            }
//            checkedList.Add(new Skill { Name = names });

//            return checkedList;
//        }

//        //private Consultancy ConsultancyCheck(string cosultancyName)
//        //{
//        //    var checkedInfo = ConsultancyRepository.CheckIfConsultancyExists(cosultancyName);

//        //    if (checkedInfo)
//        //        return new Consultancy { Name = cosultancyName };
//        //    ConsultancyRepository.Add(cosultancyName);
//        //    return new Consultancy { Name = cosultancyName };
//        //}

//        private Candidate CandidateCheck(string name)
//        {
//            var checkedInfo = CandiadteRepository.CheckIfCandidateExists(name);
//            if (checkedInfo == false)
//            {
//                Candidate newCandidate = new Candidate { Name = name };
//                return newCandidate;
//            }
//            MessageBox.Show("Already Exists!");
//            return null;
//        }

//        public List<Candidate> SearchBySkillSet(List<string> skills, string skillLevel)
//        {
//            List<Candidate> matchingCandidates = new List<Candidate>();
//            var list = CandiadteRepository.MemoryList;
//            foreach (var candidate in list)
//            {
//                var candiadteSkills = candidate.CandidateSkillSet.Skills;
//                foreach (var candidateSkill in candiadteSkills)
//                {
//                    matchingCandidates.AddRange(from searchSkill in skills where candidateSkill.Item1.Name == searchSkill select candidate);
//                }
//            }
//            return matchingCandidates;
//        }

//        public List<Candidate> SearchByConsultancy(string consultancy)
//        {
//            var list = CandiadteRepository.MemoryList;
//            return list.Where(candidate => candidate.ConsultancyName.Name == consultancy).ToList();
//        }

//        public List<Candidate> SearchByName(string name)
//        {
//            var list = CandiadteRepository.MemoryList;
//            return list.Where(candidate => candidate.Name == name).ToList();
//        }

//        public List<Candidate> SearchByInterviewDate(string input)
//        {
//            DateTime result;
//            DateTime.TryParse(input, out result);
//            var matchingCandidates = new List<Candidate>();
//            JourneyRepo JourneyRepository = new JourneyRepo();

//            if (!result.Equals(DateTime.MinValue))
//            {
//                var listJourney = JourneyRepository.GetAll();
//                foreach (var journey in listJourney)
//                {
//                    var re = journey.JourneyOfCandidate.Item2;
//                    foreach (var item in re)
//                    {
//                        if (item.Date > result)
//                            matchingCandidates.Add(journey.JourneyOfCandidate.Item1);
//                    }
//                }

//            }
//            return matchingCandidates;
//        }

//        public Journey SearchByCandiateJourney(string name)
//        {
//            var list = new JourneyRepo();
//            var Result = new Journey();
//            var interviewList = InterviewRepository.MemoryList;

//            foreach (var item in list.MemoryList)
//            {
//                if (item.JourneyOfCandidate.Item1.Name == name)
//                {
//                    return item;
//                }

//            }
//            return null;
//        }
//    }
//}


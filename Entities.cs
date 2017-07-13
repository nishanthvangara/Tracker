namespace Tracker
{
    using System;
    using System.Collections.Generic;

    public class Candidate
    {
        public string Name { get; set; }

        public int YearsOfWorkExperience { get; set; }

        public SkillSet CandidateSkillSet { get; set; }

        public Consultancy ConsultancyName { get; set; }

    }

    public class Consultancy
    {
        public string Name { get; set; }
    }

    public class Interview
    {
        public DateTime Date { get; set; }

        public Panel InterviewPanel { get; set; }

        public Journey InterviewJourney { get; set; }

        public Result InterviewResult { get; set; }

    }

    public class Interviewer
    {
        public string Name { get; set; }
    }


    public class JobCategory
    {
        public JobFamily JobFamily { get; set; }

        public JobTitle JobTitle { get; set; }
    }


    public class JobFamily
    {
        public static JobFamily SoftwareDevelopement { get; } = new JobFamily("Software Developement");
        public static JobFamily BusinessAnalysis { get; } = new JobFamily("Business Analysis");

        string _jobFamily;

        JobFamily(string family)
        {
            _jobFamily = family;
        }
        public override string ToString() => _jobFamily;
    }

    public class JobTitle
    {
        public static JobTitle Associate { get; } = new JobTitle("Associate");
        public static JobTitle Regular { get; } = new JobTitle("Regular");
        public static JobTitle Senior { get; } = new JobTitle("Senior");
        public static JobTitle Lead { get; } = new JobTitle("Lead");

        string _title;

        JobTitle(string title)
        {
            _title = title;
        }
        public override string ToString() => _title;
    }

    public class Result
    {
        string Comments { get; }
        string Outcome { get; }

        Result(string outcome, string comments)
        {
            Outcome = outcome;
            Comments = comments;
        }

        public override string ToString() => $"{Outcome}. Comments: {Comments}";

        public static Result Selected(string comments) => new Result("Selected", comments);
        public static Result Rejected(string comments) => new Result("Rejected", comments);
        public static Result Recommended(string comments) => new Result("Recommended To Next Level", comments);
        public static Result Hold(string comments) => new Result("On Hold", comments);
    }

    public class Round
    {
        public static Round Telephonic { get; } = new Round("Telephonic");
        public static Round FaceToFace { get; } = new Round("FaceToFace");
        public static Round CaseStudy { get; } = new Round("CaseStudy");

        string _round;
        Round(string round)
        {
            _round = round;
        }
        public override string ToString() => _round;
    }

    public class Skill
    {
        public string Name { get; set; }
    }

    public class SkillLevel
    {
        public static SkillLevel Advanced { get; } = new SkillLevel("Advanced");

        public static SkillLevel Functional { get; } = new SkillLevel("Functional");

        public static SkillLevel Basic { get; } = new SkillLevel("Basic");

        string _skillLevel;

        SkillLevel(string skillLevel)
        {
            _skillLevel = skillLevel;
        }
        public override string ToString() => _skillLevel;
    }

    public class SkillSet
    {

        public Skill Skill { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public List<Tuple<Skill, SkillLevel>> Skills { get; set; }

    }

    public class Vacancy
    {
        public string ResponsibilitiesDescription { get; set; }

        public int MinimumYearsOfWorkExperience { get; set; }

        public JobCategory JobCategoryVacancy { get; set; }

        public List<Journey> Journeys { get; set; }

    }

    public class Journey
    {

        public List<Vacancy> Vacancies { get; set; }

        public Tuple<Candidate, List<Interview>> JourneyOfCandidate { get; set; }

    }

    public class Panel
    {
        public Interviewer PanelInterviewer { get; set; }

        public Round PanelRound { get; set; }

    }
}

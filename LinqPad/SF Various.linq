<Query Kind="Expression" />

JobVacancyAdvertContents.Where(x => x.JobVacancyID == 17021).Dump()

Users.Where(x => (x.StubCandidateEmail ?? x.Email) == "gordon.lucas05@gmail.com").Dump();
JobApplicationSyncs.FirstOrDefault(x => x.ID == new Guid("4f2e9513-c1b4-e811-8190-02a86ccfc27f")).Dump();

JobCandidates.Where(x => x.JobApplicationSyncs.Any(jas => jas.SyncEstablishedAt != null))
.Where(x => x.Status == -99)
.Select(x => new
{
	x.ID,
	x.FifoID,
	x.Fifo.User.Email,
	x.Fifo.User.StubCandidateEmail,
	x.Status,
	x.PreviousStatus,
	x.JobApplication.FinalisedAt,
	x.StatusLastChangedAt,
	x.HasApplicationQuestions,
	JASCreatedAt = x.JobApplicationSyncs.Where(jas => jas.SyncEstablishedAt != null).Select(jas => jas.CreatedAt),
	x.InitiallyNewAt,
	x.JobApplication.AutoDisqualified,
	MatchingUserID = Users.Where(u => u.Email == x.Fifo.User.StubCandidateEmail).Select(u => u.ID)
})

QueuedEmails.Where(x => x.ToEmail == "briannahughes10@hotmail.com")
LogActivities.Where(x => x.FifoID == 1086534)

JobCandidates.Where(x => x.JobApplicationSyncs.Any(jas => jas.SyncEstablishedAt != null))
.Where(x => x.Status == -99)
.Select(x => new { script = "update JobCandidate set [status] = 2,StatusLastChangedAt = GETUTCDATE()  where Id =" + x.ID, x.JobApplication.FinalisedAt })
.OrderBy(x => x.FinalisedAt)
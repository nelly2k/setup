<Query Kind="Statements">
  <Connection>
    <ID>6dd2cadd-0982-4d57-8ad5-211e41a89e5d</ID>
    <Persist>true</Persist>
    <Server>test-sql1b.corp.livehire.com</Server>
    <Database>livehire_Rep</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>C:\Git\LiveHire\Data\bin\Debug\Fifobids.Library.Data.dll</Reference>
</Query>

var email = "abida_nasiri@yahoo.com.au";
 
Users.Where(x => x.Email == email).Select(x => x.Fifo.FifoRightToWorkFiles).Dump("Right to work files");
 
Users.Where(u => u.StubCandidateEmail == email).Dump("Stub Candidate");
Users.Where(x => x.Email == email).Dump();
Users.Where(x => x.Email == email).Select(x => x.Fifo).Dump();
Users.Where(x => x.Email == email).Select(x => x.Fifo.LatestUploadedResumeFile).Dump();
Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.FifoSyncs).Dump();
//Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.FifoSyncs).SelectMany(x => x.FifoSyncEvents.OrderByDescending(y => y.Date)).Dump();
Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.JobApplicationSyncs).Dump();
//Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.JobApplicationSyncs).SelectMany(x => x.JobApplicationSyncEvents.OrderByDescending(y => y.RequestAt)).Dump();
Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.JobCandidates).Dump();
Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.JobCandidates).Select(x => x.JobApplication).Dump();
Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.JobCandidates).Select(x => x.JobApplication.Vacancy.JobVacancyAdvertContents).Dump();
Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.JobCandidates).Select( x => x.Vacancy).Dump();
Users.Where(x => x.Email == email).SelectMany(x => x.Fifo.WorkerConnections).Dump();

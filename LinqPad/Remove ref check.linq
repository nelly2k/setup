<Query Kind="Statements">
  <Connection>
    <ID>136401cd-e293-4b3d-baa1-c10e30233384</ID>
    <Persist>true</Persist>
    <Server>dev-sql1.corp.livehire.com</Server>
    <Database>livehire_Dev</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var cand = JobCandidates
.Where(x => x.VacancyID == 18907)
.Where(x => x.FifoID == 492824)
.Single();

cand.ReferenceCheckStatus = null;
SubmitChanges();
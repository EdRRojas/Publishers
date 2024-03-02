using publishers.Domain.Entities;
using publishers.Infrastructure.Contex;
using publishers.Infrastructure.Interfaces;

namespace publishers.Infrastructure.Repositories
{
    public class JobsRepository : IJobs
    {
        private readonly PubsContex contex;
        public JobsRepository(PubsContex contex) 
        {
            this.contex = contex;
        }
        public void Create(Jobs jobs)
        {
            try
            {
                this.contex.jobs.Add(jobs);
                this.contex.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Jobs GetJobById(int job_id)
        {
            return this.contex.jobs.Find(job_id);
        }

        public void Remove(Jobs jobs)
        {
            try
            {
                var jobToDelete = this.GetJobById((int)jobs.job_id);

                jobToDelete.DeleteDate = DateTime.Now;
                jobToDelete.Deleted = true;
                jobToDelete.UserDeleted = jobs.UserDeleted;

                this.contex.jobs.Update(jobToDelete);
                this.contex.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Jobs jobs)
        {
            try
            {
                var jobToUpdate = this.GetJobById((int)jobs.job_id);

                jobToUpdate.job_id = jobs.job_id;
                jobToUpdate.job_desc = jobs.job_desc;
                jobToUpdate.min_lvl = jobs.min_lvl;
                jobToUpdate.max_lvl = jobs.max_lvl;
                jobToUpdate.ModifyDate = jobs.ModifyDate;
                jobToUpdate.UserMod = jobs.UserMod;

                this.contex.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }

    }
}

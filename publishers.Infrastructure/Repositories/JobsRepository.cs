using Microsoft.Extensions.Logging;
using publishers.Domain.Entities;
using publishers.Infrastructure.Contex;
using publishers.Infrastructure.Core;
using publishers.Infrastructure.Interfaces;

namespace publishers.Infrastructure.Repositories
{
    public class JobsRepository : BaseRepository<Jobs, int>, IJobsRepository
    {
        private readonly PubsContex contex;
        private readonly ILogger<JobsRepository> logger;

        public JobsRepository(PubsContex contex, ILogger<JobsRepository> logger) : base(contex)
        {
            this.contex = contex;
            this.logger = logger;
        }

        public override void Create(Jobs entity)
        {
            try
            {
                contex.jobs.Add(entity);
                contex.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("¡Ocurrio un erro creando el trabajo!",ex.ToString());
            }
        }

        public override void Remove(Jobs job)
        {
            try
            {
                var entityToUpdate = this.GetEntityById(job.job_id);

                entityToUpdate.job_id = job.job_id;
                entityToUpdate.job_desc = job.job_desc;
                entityToUpdate.min_lvl = job.min_lvl;
                entityToUpdate.max_lvl = job.max_lvl;

                this.contex.jobs.Update(entityToUpdate);
                this.contex.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("¡Ocurrio un erro eliminando el trabajo!", ex.ToString());
            }
        }

        public override void Update(Jobs job)
        {
            try
            {
                var jobToUpdate = GetEntityById(job.job_id);

                jobToUpdate.job_id = job.job_id;
                jobToUpdate.job_desc = job.job_desc;
                jobToUpdate.min_lvl = job.min_lvl;
                jobToUpdate.max_lvl= job.max_lvl;

                contex.jobs.Update(jobToUpdate);
                contex.SaveChanges();
                

            }
            catch (Exception ex)
            {
                this.logger.LogError("¡Ocurrio un erro actualizando el trabajo!", ex.ToString());
            }
        }

        public List<Jobs> FindAll(Func<Jobs, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<Jobs> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Jobs GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Jobs GetJobByMax_lvl(int maxlvl)
        {
            throw new NotImplementedException();
        }

        public Jobs GetJobByMin_lvl(int minlvl)
        {
            throw new NotImplementedException();
        }

    }

    
}

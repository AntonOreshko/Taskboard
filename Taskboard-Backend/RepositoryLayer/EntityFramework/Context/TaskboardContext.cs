using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context.Configuration;

namespace RepositoryLayer.EntityFramework.Context
{
    public class TaskboardContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<UserBoard> UserBoards { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Subtask> Subtasks { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactRequest> ContactRequests { get; set; }

        public TaskboardContext(DbContextOptions<TaskboardContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfigurator());
            modelBuilder.ApplyConfiguration(new BoardConfigurator());
            modelBuilder.ApplyConfiguration(new UserBoardConfigurator());
            modelBuilder.ApplyConfiguration(new TaskConfigurator());
            modelBuilder.ApplyConfiguration(new SubtaskConfigurator());
            modelBuilder.ApplyConfiguration(new NoteConfigurator());
            modelBuilder.ApplyConfiguration(new ContactConfigurator());
            modelBuilder.ApplyConfiguration(new ContactRequestConfigurator());
        }
    }
}
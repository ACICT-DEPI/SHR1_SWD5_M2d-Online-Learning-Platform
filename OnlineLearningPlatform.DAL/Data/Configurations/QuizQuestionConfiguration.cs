﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.DAL.Entities;

namespace OnlineLearningPlatform.DAL.Data.Configurations
{
    public class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizQuestion> builder)
        {
            builder.HasKey(qq => qq.Id);

            builder.Property(qq => qq.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            builder.Property(qq => qq.Question)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne<Quiz>(qq => qq.Quiz)
                .WithMany(q => q.QuizQuestions)
                .HasForeignKey(qq => qq.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

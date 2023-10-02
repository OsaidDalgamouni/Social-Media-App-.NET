using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

      
        
       
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
       
    
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TRAINING_SCHEMA_OSAID");

            modelBuilder.Entity<Applicationuser>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("SYS_C002611965");

                entity.ToTable("APPLICATIONUSER");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOK");

                entity.Property(e => e.Id)
                    .HasPrecision(15)
                    .HasColumnName("ID");

                entity.Property(e => e.Author)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("AUTHOR");

                entity.Property(e => e.Numberofpage)
                    .HasPrecision(15)
                    .HasColumnName("NUMBEROFPAGE");

                entity.Property(e => e.Publishedat)
                    .HasColumnType("DATE")
                    .HasColumnName("PUBLISHEDAT");

                entity.Property(e => e.Title)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("CITYNAME");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.ToTable("LIKES");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Sourceuserid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SOURCEUSERID");

                entity.Property(e => e.Targetuserid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TARGETUSERID");

                entity.HasOne(d => d.Sourceuser)
                    .WithMany(p => p.LikeSourceusers)
                    .HasForeignKey(d => d.Sourceuserid)
                    .HasConstraintName("FK_USERS");

                entity.HasOne(d => d.Targetuser)
                    .WithMany(p => p.LikeTargetusers)
                    .HasForeignKey(d => d.Targetuserid)
                    .HasConstraintName("FK_USERT");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("MESSAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(999)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Dateread)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEREAD");

                entity.Property(e => e.Messagesent)
                    .HasColumnType("DATE")
                    .HasColumnName("MESSAGESENT");

                entity.Property(e => e.Recipientdeleted)
                    .HasPrecision(1)
                    .HasColumnName("RECIPIENTDELETED")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Recipientid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECIPIENTID");

                entity.Property(e => e.Recipientusername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RECIPIENTUSERNAME");

                entity.Property(e => e.Senderdeleted)
                    .HasPrecision(1)
                    .HasColumnName("SENDERDELETED")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Senderid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SENDERID");

                entity.Property(e => e.Senderusername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SENDERUSERNAME");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.MessageRecipients)
                    .HasForeignKey(d => d.Recipientid)
                    .HasConstraintName("RECIPIENT");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSenders)
                    .HasForeignKey(d => d.Senderid)
                    .HasConstraintName("SENDER");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.Orderid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDERID");

                entity.Property(e => e.Customername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMERNAME");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDERDATE");

                entity.Property(e => e.Totalamount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALAMOUNT");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.ToTable("ORDERITEM");

                entity.Property(e => e.Orderitemid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDERITEMID");

                entity.Property(e => e.Orderid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDERID");

                entity.Property(e => e.Productname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTNAME");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALPRICE");

                entity.Property(e => e.Unitprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNITPRICE");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("PHOTO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Ismain)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("ISMAIN")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Publicid)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PUBLICID");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_CHILD_PARENT");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.City)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Country)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Created)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Gender)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Hashpassword).HasColumnName("HASHPASSWORD");

                entity.Property(e => e.Interests)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("INTERESTS");

                entity.Property(e => e.Introduction)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("INTRODUCTION");

                entity.Property(e => e.Knownas)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KNOWNAS");

                entity.Property(e => e.Lastactive)
                    .HasColumnType("DATE")
                    .HasColumnName("LASTACTIVE");

                entity.Property(e => e.Lookingfor)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("LOOKINGFOR");

                entity.Property(e => e.Saltpassword).HasColumnName("SALTPASSWORD");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.HasSequence("BOOK_SEQ");

            modelBuilder.HasSequence("BOOKS_SEQ");

            modelBuilder.HasSequence("BOOKS_SEQUENCE");

            modelBuilder.HasSequence("LIKE_SEQ");

            modelBuilder.HasSequence("LIKES_SEQUENCE");

            modelBuilder.HasSequence("MESSAGE_SEQ");

            modelBuilder.HasSequence("ORDER_SEQ");

            modelBuilder.HasSequence("ORDERS_SEQ");

            modelBuilder.HasSequence("PHOTO_SEQ");

            modelBuilder.HasSequence("USER_SEQUENCE");

            modelBuilder.HasSequence("USERS_SEQUENCE");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

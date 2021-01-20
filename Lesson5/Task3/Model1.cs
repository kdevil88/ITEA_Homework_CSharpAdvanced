﻿namespace Task3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Контекст настроен для использования строки подключения "Model1" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Task3.Model1" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model1" 
        // в файле конфигурации приложения.
        public Model1()
            : base("name=Model1")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<BaseSource> BaseSourceList { get; set; }
         public virtual DbSet<Approaches> ApproachesList { get; set; }
    }

    public class BaseSource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Approaches
    {
        public int Id { get; set; }
        public BaseSource BasedOn { get; set; }
        public string Name { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepZone.Todos
{
    public class SnapshotService
    {
        // Fields
        private readonly TodoRepository _todoRepository = null;

        private readonly SnapshotRepository _snapshotRepository = null;


        // Constructors
        public SnapshotService(TodoRepository todoRepository, SnapshotRepository snapshotRepository)
        {
            #region Contracts

            if (todoRepository == null) throw new ArgumentException(nameof(todoRepository));
            if (snapshotRepository == null) throw new ArgumentException(nameof(snapshotRepository));

            #endregion

            // Default
            _todoRepository = todoRepository;
            _snapshotRepository = snapshotRepository;
        }


        // Methods
        public void Snapshot()
        {
            // TodoCounts
            var todoCounts = _todoRepository.CountAll();
            if (todoCounts == null) throw new InvalidOperationException(nameof(todoCounts));

            // Snapshot
            var snapshot = new Snapshot()
            {
                SnapshotId = Guid.NewGuid().ToString(),
                CreateTime = DateTime.Now,
                TotalCount = todoCounts.TotalCount,
                CompleteCount = todoCounts.CompleteCount
            };

            // Add
            _snapshotRepository.Add(snapshot);
        }
    }
}

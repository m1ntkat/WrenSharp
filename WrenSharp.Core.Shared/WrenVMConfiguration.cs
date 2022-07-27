﻿using WrenSharp.Memory;

namespace WrenSharp
{
    /// <summary>
    /// A configuration class for a Wren VM instance. This class provides a C# friendly interface for setting
    /// the Wren C API configuration, using pure C# types to wrap around the native API.
    /// </summary>
    public partial class WrenVMConfiguration
    {
        /// <summary>
        /// The allocator to use for unmanaged memory. Some WrenSharp features use unmanaged memory for performance reasons.
        /// If null, the default allocator <see cref="HGlobalAllocator.Default"/> is used.
        /// </summary>
        public IAllocator Allocator { get; set; }

        /// <summary>
        /// A delegate that is called when when an error occurs within the Wren VM.
        /// </summary>
        public IWrenErrorOutput ErrorOutput { get; set; }

        /// <summary>
        /// A delegate that is called when Wren's System.print() method is invoked.
        /// </summary>
        public IWrenWriteOutput WriteOutput { get; set; }

        /// <summary>
        /// The object responsible for locating and loading Wren module source.
        /// </summary>
        public IWrenModuleProvider ModuleProvider { get; set; }

        /// <summary>
        /// The object responsible for resolving Wren module names. If module name resolution is not required, this
        /// property can be left null.
        /// </summary>
        public IWrenModuleResolver ModuleResolver { get; set; }

        /// <summary>
        /// Indicates if errors are logged and stored in the <see cref="WrenVM.Errors"/> log, as <see cref="WrenError"/> instances.
        /// </summary>
        public bool LogErrors { get; set; }

        /// <summary>
        /// <para>
        /// The number of bytes Wren will allocate before triggering the first garbage collection.
        /// </para>
        /// If null, uses the Wren default (10MB).
        /// </summary>
        public ulong? InitialHeapSize { get; set; }

        /// <summary>
        /// <para>
        /// After a collection occurs, the threshold for the next collection is
        /// determined based on the number of bytes remaining in use. This allows Wren
        /// to shrink its memory usage automatically after reclaiming a large amount
        /// of memory.
        /// </para>
        /// <para>
        /// This can be used to ensure that the heap does not get too small, which can
        /// in turn lead to a large number of collections afterwards as the heap grows
        /// back to a usable size.
        /// </para>
        /// If null, uses the Wren default (1MB).
        /// </summary>
        public ulong? MinHeapSize { get; set; }

        /// <summary>
        /// <para>
        /// Wren will resize the heap automatically as the number of bytes
        /// remaining in use after a collection changes. This number determines the
        /// amount of additional memory Wren will use after a collection, as a
        /// percentage of the current heap size.
        /// </para>
        /// <para>
        /// For example, say that this is 50. After a garbage collection, when there
        /// are 400 bytes of memory still in use, the next collection will be triggered
        /// after a total of 600 bytes are allocated (including the 400 already in
        /// use.)
        /// </para>
        /// <para>
        /// Setting this to a smaller number wastes less memory, but triggers more
        /// frequent garbage collections.
        /// </para>
        /// If null, uses the Wren default (50%).
        /// </summary>
        public float? HeapGrowthPercent { get; set; }

        /// <summary>
        /// Creates a shallow copy of this <see cref="WrenVMConfiguration"/>.
        /// </summary>
        /// <returns>A new <see cref="WrenVMConfiguration"/> that is a shallow copy of this configuration.</returns>
        public WrenVMConfiguration Clone()
        {
            return (WrenVMConfiguration)MemberwiseClone();
        }
    }
}
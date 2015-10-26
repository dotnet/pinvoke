// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Win32 error codes (As returned by GetLastError).
    /// </summary>
    /// <remarks>
    /// Converted from winerror.h
    /// </remarks>
    public enum Win32ErrorCode
    {
        /// <summary>
        /// The operation completed successfully.
        /// </summary>
        Success = 0x00000000,

        /// <summary>
        /// Incorrect function.
        /// </summary>
        InvalidFunction = 0x00000001,

        /// <summary>
        /// The system cannot find the file specified.
        /// </summary>
        FileNotFound = 0x00000002,

        /// <summary>
        /// The system cannot find the path specified.
        /// </summary>
        PathNotFound = 0x00000003,

        /// <summary>
        /// The system cannot open the file.
        /// </summary>
        TooManyOpenFiles = 0x00000004,

        /// <summary>
        /// Access is denied.
        /// </summary>
        AccessDenied = 0x00000005,

        /// <summary>
        /// The handle is invalid.
        /// </summary>
        InvalidHandle = 0x00000006,

        /// <summary>
        /// The storage control blocks were destroyed.
        /// </summary>
        ArenaTrashed = 0x00000007,

        /// <summary>
        /// Not enough storage is available to process this command.
        /// </summary>
        NotEnoughMemory = 0x00000008,

        /// <summary>
        /// The storage control block address is invalid.
        /// </summary>
        InvalidBlock = 0x00000009,

        /// <summary>
        /// The environment is incorrect.
        /// </summary>
        BadEnvironment = 0x0000000A,

        /// <summary>
        /// An attempt was made to load a program with an incorrect format.
        /// </summary>
        BadFormat = 0x0000000B,

        /// <summary>
        /// The access code is invalid.
        /// </summary>
        InvalidAccess = 0x0000000C,

        /// <summary>
        /// The data is invalid.
        /// </summary>
        InvalidData = 0x0000000D,

        /// <summary>
        /// Not enough storage is available to complete this operation.
        /// </summary>
        Outofmemory = 0x0000000E,

        /// <summary>
        /// The system cannot find the drive specified.
        /// </summary>
        InvalidDrive = 0x0000000F,

        /// <summary>
        /// The directory cannot be removed.
        /// </summary>
        CurrentDirectory = 0x00000010,

        /// <summary>
        /// The system cannot move the file to a different disk drive.
        /// </summary>
        NotSameDevice = 0x00000011,

        /// <summary>
        /// There are no more files.
        /// </summary>
        NoMoreFiles = 0x00000012,

        /// <summary>
        /// The media is write protected.
        /// </summary>
        WriteProtect = 0x00000013,

        /// <summary>
        /// The system cannot find the device specified.
        /// </summary>
        BadUnit = 0x00000014,

        /// <summary>
        /// The device is not ready.
        /// </summary>
        NotReady = 0x00000015,

        /// <summary>
        /// The device does not recognize the command.
        /// </summary>
        BadCommand = 0x00000016,

        /// <summary>
        /// Data error (cyclic redundancy check).
        /// </summary>
        Crc = 0x00000017,

        /// <summary>
        /// The program issued a command but the command length is incorrect.
        /// </summary>
        BadLength = 0x00000018,

        /// <summary>
        /// The drive cannot locate a specific area or track on the disk.
        /// </summary>
        Seek = 0x00000019,

        /// <summary>
        /// The specified disk or diskette cannot be accessed.
        /// </summary>
        NotDosDisk = 0x0000001A,

        /// <summary>
        /// The drive cannot find the sector requested.
        /// </summary>
        SectorNotFound = 0x0000001B,

        /// <summary>
        /// The printer is out of paper.
        /// </summary>
        OutOfPaper = 0x0000001C,

        /// <summary>
        /// The system cannot write to the specified device.
        /// </summary>
        WriteFault = 0x0000001D,

        /// <summary>
        /// The system cannot read from the specified device.
        /// </summary>
        ReadFault = 0x0000001E,

        /// <summary>
        /// A device attached to the system is not functioning.
        /// </summary>
        GenFailure = 0x0000001F,

        /// <summary>
        /// The process cannot access the file because it is being used by another process.
        /// </summary>
        SharingViolation = 0x00000020,

        /// <summary>
        /// The process cannot access the file because another process has locked a portion of the file.
        /// </summary>
        LockViolation = 0x00000021,

        /// <summary>
        /// The wrong diskette is in the drive.
        /// Insert %2 (Volume Serial Number: %3) into drive %1.
        /// </summary>
        WrongDisk = 0x00000022,

        /// <summary>
        /// Too many files opened for sharing.
        /// </summary>
        SharingBufferExceeded = 0x00000024,

        /// <summary>
        /// Reached the end of the file.
        /// </summary>
        HandleEof = 0x00000026,

        /// <summary>
        /// The disk is full.
        /// </summary>
        HandleDiskFull = 0x00000027,

        /// <summary>
        /// The request is not supported.
        /// </summary>
        NotSupported = 0x00000032,

        /// <summary>
        /// Windows cannot find the network path. Verify that the network path is correct and the destination computer is not busy or turned off. If Windows still cannot find the network path, contact your network administrator.
        /// </summary>
        RemNotList = 0x00000033,

        /// <summary>
        /// You were not connected because a duplicate name exists on the network. If joining a domain, go to System in Control Panel to change the computer name and try again. If joining a workgroup, choose another workgroup name.
        /// </summary>
        DupName = 0x00000034,

        /// <summary>
        /// The network path was not found.
        /// </summary>
        BadNetpath = 0x00000035,

        /// <summary>
        /// The network is busy.
        /// </summary>
        NetworkBusy = 0x00000036,

        /// <summary>
        /// The specified network resource or device is no longer available.
        /// </summary>
        DevNotExist = 0x00000037,

        /// <summary>
        /// The network BIOS command limit has been reached.
        /// </summary>
        TooManyCmds = 0x00000038,

        /// <summary>
        /// A network adapter hardware error occurred.
        /// </summary>
        AdapHdwErr = 0x00000039,

        /// <summary>
        /// The specified server cannot perform the requested operation.
        /// </summary>
        BadNetResp = 0x0000003A,

        /// <summary>
        /// An unexpected network error occurred.
        /// </summary>
        UnexpNetErr = 0x0000003B,

        /// <summary>
        /// The remote adapter is not compatible.
        /// </summary>
        BadRemAdap = 0x0000003C,

        /// <summary>
        /// The printer queue is full.
        /// </summary>
        PrintqFull = 0x0000003D,

        /// <summary>
        /// Space to store the file waiting to be printed is not available on the server.
        /// </summary>
        NoSpoolSpace = 0x0000003E,

        /// <summary>
        /// Your file waiting to be printed was deleted.
        /// </summary>
        PrintCancelled = 0x0000003F,

        /// <summary>
        /// The specified network name is no longer available.
        /// </summary>
        NetnameDeleted = 0x00000040,

        /// <summary>
        /// Network access is denied.
        /// </summary>
        NetworkAccessDenied = 0x00000041,

        /// <summary>
        /// The network resource type is not correct.
        /// </summary>
        BadDevType = 0x00000042,

        /// <summary>
        /// The network name cannot be found.
        /// </summary>
        BadNetName = 0x00000043,

        /// <summary>
        /// The name limit for the local computer network adapter card was exceeded.
        /// </summary>
        TooManyNames = 0x00000044,

        /// <summary>
        /// The network BIOS session limit was exceeded.
        /// </summary>
        TooManySess = 0x00000045,

        /// <summary>
        /// The remote server has been paused or is in the process of being started.
        /// </summary>
        SharingPaused = 0x00000046,

        /// <summary>
        /// No more connections can be made to this remote computer at this time because there are already as many connections as the computer can accept.
        /// </summary>
        ReqNotAccep = 0x00000047,

        /// <summary>
        /// The specified printer or disk device has been paused.
        /// </summary>
        RedirPaused = 0x00000048,

        /// <summary>
        /// The file exists.
        /// </summary>
        FileExists = 0x00000050,

        /// <summary>
        /// The directory or file cannot be created.
        /// </summary>
        CannotMake = 0x00000052,

        /// <summary>
        /// Fail on INT 24.
        /// </summary>
        FailI24 = 0x00000053,

        /// <summary>
        /// Storage to process this request is not available.
        /// </summary>
        OutOfStructures = 0x00000054,

        /// <summary>
        /// The local device name is already in use.
        /// </summary>
        AlreadyAssigned = 0x00000055,

        /// <summary>
        /// The specified network password is not correct.
        /// </summary>
        InvalidPassword = 0x00000056,

        /// <summary>
        /// The parameter is incorrect.
        /// </summary>
        InvalidParameter = 0x00000057,

        /// <summary>
        /// A write fault occurred on the network.
        /// </summary>
        NetWriteFault = 0x00000058,

        /// <summary>
        /// The system cannot start another process at this time.
        /// </summary>
        NoProcSlots = 0x00000059,

        /// <summary>
        /// Cannot create another system semaphore.
        /// </summary>
        TooManySemaphores = 0x00000064,

        /// <summary>
        /// The exclusive semaphore is owned by another process.
        /// </summary>
        ExclSemAlreadyOwned = 0x00000065,

        /// <summary>
        /// The semaphore is set and cannot be closed.
        /// </summary>
        SemIsSet = 0x00000066,

        /// <summary>
        /// The semaphore cannot be set again.
        /// </summary>
        TooManySemRequests = 0x00000067,

        /// <summary>
        /// Cannot request exclusive semaphores at interrupt time.
        /// </summary>
        InvalidAtInterruptTime = 0x00000068,

        /// <summary>
        /// The previous ownership of this semaphore has ended.
        /// </summary>
        SemOwnerDied = 0x00000069,

        /// <summary>
        /// Insert the diskette for drive %1.
        /// </summary>
        SemUserLimit = 0x0000006A,

        /// <summary>
        /// The program stopped because an alternate diskette was not inserted.
        /// </summary>
        DiskChange = 0x0000006B,

        /// <summary>
        /// The disk is in use or locked by another process.
        /// </summary>
        DriveLocked = 0x0000006C,

        /// <summary>
        /// The pipe has been ended.
        /// </summary>
        BrokenPipe = 0x0000006D,

        /// <summary>
        /// The system cannot open the device or file specified.
        /// </summary>
        OpenFailed = 0x0000006E,

        /// <summary>
        /// The file name is too long.
        /// </summary>
        BufferOverflow = 0x0000006F,

        /// <summary>
        /// There is not enough space on the disk.
        /// </summary>
        DiskFull = 0x00000070,

        /// <summary>
        /// No more internal file identifiers available.
        /// </summary>
        NoMoreSearchHandles = 0x00000071,

        /// <summary>
        /// The target internal file identifier is incorrect.
        /// </summary>
        InvalidTargetHandle = 0x00000072,

        /// <summary>
        /// The IOCTL call made by the application program is not correct.
        /// </summary>
        InvalidCategory = 0x00000075,

        /// <summary>
        /// The verify-on-write switch parameter value is not correct.
        /// </summary>
        InvalidVerifySwitch = 0x00000076,

        /// <summary>
        /// The system does not support the command requested.
        /// </summary>
        BadDriverLevel = 0x00000077,

        /// <summary>
        /// This function is not supported on this system.
        /// </summary>
        CallNotImplemented = 0x00000078,

        /// <summary>
        /// The semaphore timeout period has expired.
        /// </summary>
        SemTimeout = 0x00000079,

        /// <summary>
        /// The data area passed to a system call is too small.
        /// </summary>
        InsufficientBuffer = 0x0000007A,

        /// <summary>
        /// The filename, directory name, or volume label syntax is incorrect.
        /// </summary>
        InvalidName = 0x0000007B,

        /// <summary>
        /// The system call level is not correct.
        /// </summary>
        InvalidLevel = 0x0000007C,

        /// <summary>
        /// The disk has no volume label.
        /// </summary>
        NoVolumeLabel = 0x0000007D,

        /// <summary>
        /// The specified module could not be found.
        /// </summary>
        ModNotFound = 0x0000007E,

        /// <summary>
        /// The specified procedure could not be found.
        /// </summary>
        ProcNotFound = 0x0000007F,

        /// <summary>
        /// There are no child processes to wait for.
        /// </summary>
        WaitNoChildren = 0x00000080,

        /// <summary>
        /// The %1 application cannot be run in Win32 mode.
        /// </summary>
        ChildNotComplete = 0x00000081,

        /// <summary>
        /// Attempt to use a file handle to an open disk partition for an operation other than raw disk I/O.
        /// </summary>
        DirectAccessHandle = 0x00000082,

        /// <summary>
        /// An attempt was made to move the file pointer before the beginning of the file.
        /// </summary>
        NegativeSeek = 0x00000083,

        /// <summary>
        /// The file pointer cannot be set on the specified device or file.
        /// </summary>
        SeekOnDevice = 0x00000084,

        /// <summary>
        /// A JOIN or SUBST command cannot be used for a drive that contains previously joined drives.
        /// </summary>
        IsJoinTarget = 0x00000085,

        /// <summary>
        /// An attempt was made to use a JOIN or SUBST command on a drive that has already been joined.
        /// </summary>
        IsJoined = 0x00000086,

        /// <summary>
        /// An attempt was made to use a JOIN or SUBST command on a drive that has already been substituted.
        /// </summary>
        IsSubsted = 0x00000087,

        /// <summary>
        /// The system tried to delete the JOIN of a drive that is not joined.
        /// </summary>
        NotJoined = 0x00000088,

        /// <summary>
        /// The system tried to delete the substitution of a drive that is not substituted.
        /// </summary>
        NotSubsted = 0x00000089,

        /// <summary>
        /// The system tried to join a drive to a directory on a joined drive.
        /// </summary>
        JoinToJoin = 0x0000008A,

        /// <summary>
        /// The system tried to substitute a drive to a directory on a substituted drive.
        /// </summary>
        SubstToSubst = 0x0000008B,

        /// <summary>
        /// The system tried to join a drive to a directory on a substituted drive.
        /// </summary>
        JoinToSubst = 0x0000008C,

        /// <summary>
        /// The system tried to SUBST a drive to a directory on a joined drive.
        /// </summary>
        SubstToJoin = 0x0000008D,

        /// <summary>
        /// The system cannot perform a JOIN or SUBST at this time.
        /// </summary>
        BusyDrive = 0x0000008E,

        /// <summary>
        /// The system cannot join or substitute a drive to or for a directory on the same drive.
        /// </summary>
        SameDrive = 0x0000008F,

        /// <summary>
        /// The directory is not a subdirectory of the root directory.
        /// </summary>
        DirNotRoot = 0x00000090,

        /// <summary>
        /// The directory is not empty.
        /// </summary>
        DirNotEmpty = 0x00000091,

        /// <summary>
        /// The path specified is being used in a substitute.
        /// </summary>
        IsSubstPath = 0x00000092,

        /// <summary>
        /// Not enough resources are available to process this command.
        /// </summary>
        IsJoinPath = 0x00000093,

        /// <summary>
        /// The path specified cannot be used at this time.
        /// </summary>
        PathBusy = 0x00000094,

        /// <summary>
        /// An attempt was made to join or substitute a drive for which a directory on the drive is the target of a previous substitute.
        /// </summary>
        IsSubstTarget = 0x00000095,

        /// <summary>
        /// System trace information was not specified in your CONFIG.SYS file, or tracing is disallowed.
        /// </summary>
        SystemTrace = 0x00000096,

        /// <summary>
        /// The number of specified semaphore events for DosMuxSemWait is not correct.
        /// </summary>
        InvalidEventCount = 0x00000097,

        /// <summary>
        /// DosMuxSemWait did not execute; too many semaphores are already set.
        /// </summary>
        TooManyMuxwaiters = 0x00000098,

        /// <summary>
        /// The DosMuxSemWait list is not correct.
        /// </summary>
        InvalidListFormat = 0x00000099,

        /// <summary>
        /// The volume label you entered exceeds the label character limit of the target file system.
        /// </summary>
        LabelTooLong = 0x0000009A,

        /// <summary>
        /// Cannot create another thread.
        /// </summary>
        TooManyTcbs = 0x0000009B,

        /// <summary>
        /// The recipient process has refused the signal.
        /// </summary>
        SignalRefused = 0x0000009C,

        /// <summary>
        /// The segment is already discarded and cannot be locked.
        /// </summary>
        Discarded = 0x0000009D,

        /// <summary>
        /// The segment is already unlocked.
        /// </summary>
        NotLocked = 0x0000009E,

        /// <summary>
        /// The address for the thread ID is not correct.
        /// </summary>
        BadThreadidAddr = 0x0000009F,

        /// <summary>
        /// One or more arguments are not correct.
        /// </summary>
        BadArguments = 0x000000A0,

        /// <summary>
        /// The specified path is invalid.
        /// </summary>
        BadPathname = 0x000000A1,

        /// <summary>
        /// A signal is already pending.
        /// </summary>
        SignalPending = 0x000000A2,

        /// <summary>
        /// No more threads can be created in the system.
        /// </summary>
        MaxThrdsReached = 0x000000A4,

        /// <summary>
        /// Unable to lock a region of a file.
        /// </summary>
        LockFailed = 0x000000A7,

        /// <summary>
        /// The requested resource is in use.
        /// </summary>
        Busy = 0x000000AA,

        /// <summary>
        /// A lock request was not outstanding for the supplied cancel region.
        /// </summary>
        CancelViolation = 0x000000AD,

        /// <summary>
        /// The system detected a segment number that was not correct.
        /// </summary>
        InvalidSegmentNumber = 0x000000B4,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        InvalidOrdinal = 0x000000B6,

        /// <summary>
        /// Cannot create a file when that file already exists.
        /// </summary>
        AlreadyExists = 0x000000B7,

        /// <summary>
        /// The flag passed is not correct.
        /// </summary>
        InvalidFlagNumber = 0x000000BA,

        /// <summary>
        /// The specified system semaphore name was not found.
        /// </summary>
        SemNotFound = 0x000000BB,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        InvalidStartingCodeseg = 0x000000BC,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        InvalidStackseg = 0x000000BD,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        InvalidModuletype = 0x000000BE,

        /// <summary>
        /// Cannot run %1 in Win32 mode.
        /// </summary>
        InvalidExeSignature = 0x000000BF,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        ExeMarkedInvalid = 0x000000C0,

        /// <summary>
        /// %1 is not a valid Win32 application.
        /// </summary>
        BadExeFormat = 0x000000C1,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        IteratedDataExceeds64K = 0x000000C2,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        InvalidMinallocsize = 0x000000C3,

        /// <summary>
        /// The operating system cannot run this application program.
        /// </summary>
        DynlinkFromInvalidRing = 0x000000C4,

        /// <summary>
        /// The operating system is not presently configured to run this application.
        /// </summary>
        IoplNotEnabled = 0x000000C5,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        InvalidSegdpl = 0x000000C6,

        /// <summary>
        /// The operating system cannot run this application program.
        /// </summary>
        AutodatasegExceeds64K = 0x000000C7,

        /// <summary>
        /// The code segment cannot be greater than or equal to 64K.
        /// </summary>
        Ring2SegMustBeMovable = 0x000000C8,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        RelocChainXeedsSeglim = 0x000000C9,

        /// <summary>
        /// The operating system cannot run %1.
        /// </summary>
        InfloopInRelocChain = 0x000000CA,

        /// <summary>
        /// The system could not find the environment option that was entered.
        /// </summary>
        EnvvarNotFound = 0x000000CB,

        /// <summary>
        /// No process in the command subtree has a signal handler.
        /// </summary>
        NoSignalSent = 0x000000CD,

        /// <summary>
        /// The filename or extension is too long.
        /// </summary>
        FilenameExcedRange = 0x000000CE,

        /// <summary>
        /// The ring 2 stack is in use.
        /// </summary>
        Ring2StackInUse = 0x000000CF,

        /// <summary>
        /// The global filename characters, * or ?, are entered incorrectly or too many global filename characters are specified.
        /// </summary>
        MetaExpansionTooLong = 0x000000D0,

        /// <summary>
        /// The signal being posted is not correct.
        /// </summary>
        InvalidSignalNumber = 0x000000D1,

        /// <summary>
        /// The signal handler cannot be set.
        /// </summary>
        Thread1Inactive = 0x000000D2,

        /// <summary>
        /// The segment is locked and cannot be reallocated.
        /// </summary>
        Locked = 0x000000D4,

        /// <summary>
        /// Too many dynamic-link modules are attached to this program or dynamic-link module.
        /// </summary>
        TooManyModules = 0x000000D6,

        /// <summary>
        /// Cannot nest calls to LoadModule.
        /// </summary>
        NestingNotAllowed = 0x000000D7,

        /// <summary>
        /// This version of %1 is not compatible with the version of Windows you're running. Check your computer's system information and then contact the software publisher.
        /// </summary>
        ExeMachineTypeMismatch = 0x000000D8,

        /// <summary>
        /// This file is checked out or locked for editing by another user.
        /// </summary>
        FileCheckedOut = 0x000000DC,

        /// <summary>
        /// The file must be checked out before saving changes.
        /// </summary>
        CheckoutRequired = 0x000000DD,

        /// <summary>
        /// The file type being saved or retrieved has been blocked.
        /// </summary>
        BadFileType = 0x000000DE,

        /// <summary>
        /// The file size exceeds the limit allowed and cannot be saved.
        /// </summary>
        FileTooLarge = 0x000000DF,

        /// <summary>
        /// Access Denied. Before opening files in this location, you must first add the web site to your trusted sites list, browse to the web site, and select the option to login automatically.
        /// </summary>
        FormsAuthRequired = 0x000000E0,

        /// <summary>
        /// Operation did not complete successfully because the file contains a virus or potentially unwanted software.
        /// </summary>
        VirusInfected = 0x000000E1,

        /// <summary>
        /// This file contains a virus or potentially unwanted software and cannot be opened. Due to the nature of this virus or potentially unwanted software, the file has been removed from this location.
        /// </summary>
        VirusDeleted = 0x000000E2,

        /// <summary>
        /// The pipe is local.
        /// </summary>
        PipeLocal = 0x000000E5,

        /// <summary>
        /// The pipe state is invalid.
        /// </summary>
        BadPipe = 0x000000E6,

        /// <summary>
        /// All pipe instances are busy.
        /// </summary>
        PipeBusy = 0x000000E7,

        /// <summary>
        /// The pipe is being closed.
        /// </summary>
        NoData = 0x000000E8,

        /// <summary>
        /// No process is on the other end of the pipe.
        /// </summary>
        PipeNotConnected = 0x000000E9,

        /// <summary>
        /// More data is available.
        /// </summary>
        MoreData = 0x000000EA,

        /// <summary>
        /// The session was canceled.
        /// </summary>
        VcDisconnected = 0x000000F0,

        /// <summary>
        /// The specified extended attribute name was invalid.
        /// </summary>
        InvalidEaName = 0x000000FE,

        /// <summary>
        /// The extended attributes are inconsistent.
        /// </summary>
        EaListInconsistent = 0x000000FF,

        /// <summary>
        /// The wait operation timed out.
        /// </summary>
        WaitTimeout = 0x00000102,

        /// <summary>
        /// No more data is available.
        /// </summary>
        NoMoreItems = 0x00000103,

        /// <summary>
        /// The copy functions cannot be used.
        /// </summary>
        CannotCopy = 0x0000010A,

        /// <summary>
        /// The directory name is invalid.
        /// </summary>
        Directory = 0x0000010B,

        /// <summary>
        /// The extended attributes did not fit in the buffer.
        /// </summary>
        EasDidntFit = 0x00000113,

        /// <summary>
        /// The extended attribute file on the mounted file system is corrupt.
        /// </summary>
        EaFileCorrupt = 0x00000114,

        /// <summary>
        /// The extended attribute table file is full.
        /// </summary>
        EaTableFull = 0x00000115,

        /// <summary>
        /// The specified extended attribute handle is invalid.
        /// </summary>
        InvalidEaHandle = 0x00000116,

        /// <summary>
        /// The mounted file system does not support extended attributes.
        /// </summary>
        EasNotSupported = 0x0000011A,

        /// <summary>
        /// Attempt to release mutex not owned by caller.
        /// </summary>
        NotOwner = 0x00000120,

        /// <summary>
        /// Too many posts were made to a semaphore.
        /// </summary>
        TooManyPosts = 0x0000012A,

        /// <summary>
        /// Only part of a ReadProcessMemory or WriteProcessMemory request was completed.
        /// </summary>
        PartialCopy = 0x0000012B,

        /// <summary>
        /// The oplock request is denied.
        /// </summary>
        OplockNotGranted = 0x0000012C,

        /// <summary>
        /// An invalid oplock acknowledgment was received by the system.
        /// </summary>
        InvalidOplockProtocol = 0x0000012D,

        /// <summary>
        /// The volume is too fragmented to complete this operation.
        /// </summary>
        DiskTooFragmented = 0x0000012E,

        /// <summary>
        /// The file cannot be opened because it is in the process of being deleted.
        /// </summary>
        DeletePending = 0x0000012F,

        /// <summary>
        /// A requested file lock operation cannot be processed due to an invalid byte range.
        /// </summary>
        InvalidLockRange = 0x00000133,

        /// <summary>
        /// An invalid exception handler routine has been detected.
        /// </summary>
        InvalidExceptionHandler = 0x00000136,

        /// <summary>
        /// Duplicate privileges were specified for the token.
        /// </summary>
        DuplicatePrivileges = 0x00000137,

        /// <summary>
        /// No ranges for the specified operation were able to be processed.
        /// </summary>
        NoRangesProcessed = 0x00000138,

        /// <summary>
        /// The physical resources of this disk have been exhausted.
        /// </summary>
        DiskResourcesExhausted = 0x0000013A,

        /// <summary>
        /// The token representing the data is invalid.
        /// </summary>
        InvalidToken = 0x0000013B,

        /// <summary>
        /// The system cannot find message text for message number 0x%1 in the message file for %2.
        /// </summary>
        MrMidNotFound = 0x0000013D,

        /// <summary>
        /// The scope specified was not found.
        /// </summary>
        ScopeNotFound = 0x0000013E,

        /// <summary>
        /// The Central Access Policy specified is not defined on the target machine.
        /// </summary>
        UndefinedScope = 0x0000013F,

        /// <summary>
        /// The Central Access Policy obtained from Active Directory is invalid.
        /// </summary>
        InvalidCap = 0x00000140,

        /// <summary>
        /// The device is unreachable.
        /// </summary>
        DeviceUnreachable = 0x00000141,

        /// <summary>
        /// The target device has insufficient resources to complete the operation.
        /// </summary>
        DeviceNoResources = 0x00000142,

        /// <summary>
        /// A data integrity checksum error occurred. Data in the file stream is corrupt.
        /// </summary>
        DataChecksumError = 0x00000143,

        /// <summary>
        /// An operation is currently in progress with the device.
        /// </summary>
        OperationInProgress = 0x00000149,

        /// <summary>
        /// An attempt was made to send down the command via an invalid path to the target device.
        /// </summary>
        BadDevicePath = 0x0000014A,

        /// <summary>
        /// The command specified a number of descriptors that exceeded the maximum supported by the device.
        /// </summary>
        TooManyDescriptors = 0x0000014B,

        /// <summary>
        /// Scrub is disabled on the specified file.
        /// </summary>
        ScrubDataDisabled = 0x0000014C,

        /// <summary>
        /// The storage device does not provide redundancy.
        /// </summary>
        NotRedundantStorage = 0x0000014D,

        /// <summary>
        /// An operation is not supported on a directory.
        /// </summary>
        DirectoryNotSupported = 0x00000150,

        /// <summary>
        /// The specified copy of the requested data could not be read.
        /// </summary>
        NotReadFromCopy = 0x00000151,

        /// <summary>
        /// The specified data could not be written to any of the copies.
        /// </summary>
        FtWriteFailure = 0x00000152,

        /// <summary>
        /// One or more copies of data on this device may be out of sync. No writes may be performed until a data integrity scan is completed.
        /// </summary>
        FtDiScanRequired = 0x00000153,

        /// <summary>
        /// The supplied PEP information version is invalid.
        /// </summary>
        InvalidPepInfoVersion = 0x00000155,

        /// <summary>
        /// No action was taken as a system reboot is required.
        /// </summary>
        FailNoactionReboot = 0x0000015E,

        /// <summary>
        /// The shutdown operation failed.
        /// </summary>
        FailShutdown = 0x0000015F,

        /// <summary>
        /// The restart operation failed.
        /// </summary>
        FailRestart = 0x00000160,

        /// <summary>
        /// The maximum number of sessions has been reached.
        /// </summary>
        MaxSessionsReached = 0x00000161,

        /// <summary>
        /// The request failed due to a fatal device hardware error.
        /// </summary>
        DeviceHardwareError = 0x000001E3,

        /// <summary>
        /// Attempt to access invalid address.
        /// </summary>
        InvalidAddress = 0x000001E7,

        /// <summary>
        /// User profile cannot be loaded.
        /// </summary>
        UserProfileLoad = 0x000001F4,

        /// <summary>
        /// Arithmetic result exceeded 32 bits.
        /// </summary>
        ArithmeticOverflow = 0x00000216,

        /// <summary>
        /// There is a process on other end of the pipe.
        /// </summary>
        PipeConnected = 0x00000217,

        /// <summary>
        /// Waiting for a process to open the other end of the pipe.
        /// </summary>
        PipeListening = 0x00000218,

        /// <summary>
        /// Application verifier has found an error in the current process.
        /// </summary>
        VerifierStop = 0x00000219,

        /// <summary>
        /// An error occurred in the ABIOS subsystem.
        /// </summary>
        AbiosError = 0x0000021A,

        /// <summary>
        /// A warning occurred in the WX86 subsystem.
        /// </summary>
        Wx86Warning = 0x0000021B,

        /// <summary>
        /// An error occurred in the WX86 subsystem.
        /// </summary>
        Wx86Error = 0x0000021C,

        /// <summary>
        /// An attempt was made to cancel or set a timer that has an associated APC and the subject thread is not the thread that originally set the timer with an associated APC routine.
        /// </summary>
        TimerNotCanceled = 0x0000021D,

        /// <summary>
        /// Unwind exception code.
        /// </summary>
        Unwind = 0x0000021E,

        /// <summary>
        /// An invalid or unaligned stack was encountered during an unwind operation.
        /// </summary>
        BadStack = 0x0000021F,

        /// <summary>
        /// An invalid unwind target was encountered during an unwind operation.
        /// </summary>
        InvalidUnwindTarget = 0x00000220,

        /// <summary>
        /// Invalid Object Attributes specified to NtCreatePort or invalid Port Attributes specified to NtConnectPort
        /// </summary>
        InvalidPortAttributes = 0x00000221,

        /// <summary>
        /// Length of message passed to NtRequestPort or NtRequestWaitReplyPort was longer than the maximum message allowed by the port.
        /// </summary>
        PortMessageTooLong = 0x00000222,

        /// <summary>
        /// An attempt was made to lower a quota limit below the current usage.
        /// </summary>
        InvalidQuotaLower = 0x00000223,

        /// <summary>
        /// An attempt was made to attach to a device that was already attached to another device.
        /// </summary>
        DeviceAlreadyAttached = 0x00000224,

        /// <summary>
        /// An attempt was made to execute an instruction at an unaligned address and the host system does not support unaligned instruction references.
        /// </summary>
        InstructionMisalignment = 0x00000225,

        /// <summary>
        /// Profiling not started.
        /// </summary>
        ProfilingNotStarted = 0x00000226,

        /// <summary>
        /// Profiling not stopped.
        /// </summary>
        ProfilingNotStopped = 0x00000227,

        /// <summary>
        /// The passed ACL did not contain the minimum required information.
        /// </summary>
        CouldNotInterpret = 0x00000228,

        /// <summary>
        /// The number of active profiling objects is at the maximum and no more may be started.
        /// </summary>
        ProfilingAtLimit = 0x00000229,

        /// <summary>
        /// Used to indicate that an operation cannot continue without blocking for I/O.
        /// </summary>
        CantWait = 0x0000022A,

        /// <summary>
        /// Indicates that a thread attempted to terminate itself by default (called NtTerminateThread with NULL) and it was the last thread in the current process.
        /// </summary>
        CantTerminateSelf = 0x0000022B,

        /// <summary>
        /// If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the following errors which is guaranteed to be in the filter.
        /// In this case information is lost, however, the filter correctly handles the exception.
        /// </summary>
        UnexpectedMmCreateErr = 0x0000022C,

        /// <summary>
        /// If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the following errors which is guaranteed to be in the filter.
        /// In this case information is lost, however, the filter correctly handles the exception.
        /// </summary>
        UnexpectedMmMapError = 0x0000022D,

        /// <summary>
        /// If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the following errors which is guaranteed to be in the filter.
        /// In this case information is lost, however, the filter correctly handles the exception.
        /// </summary>
        UnexpectedMmExtendErr = 0x0000022E,

        /// <summary>
        /// A malformed function table was encountered during an unwind operation.
        /// </summary>
        BadFunctionTable = 0x0000022F,

        /// <summary>
        /// Indicates that an attempt was made to assign protection to a file system file or directory and one of the SIDs in the security descriptor could not be translated into a GUID that could be stored by the file system.
        /// This causes the protection attempt to fail, which may cause a file creation attempt to fail.
        /// </summary>
        NoGuidTranslation = 0x00000230,

        /// <summary>
        /// Indicates that an attempt was made to grow an LDT by setting its size, or that the size was not an even number of selectors.
        /// </summary>
        InvalidLdtSize = 0x00000231,

        /// <summary>
        /// Indicates that the starting value for the LDT information was not an integral multiple of the selector size.
        /// </summary>
        InvalidLdtOffset = 0x00000233,

        /// <summary>
        /// Indicates that the user supplied an invalid descriptor when trying to set up Ldt descriptors.
        /// </summary>
        InvalidLdtDescriptor = 0x00000234,

        /// <summary>
        /// Indicates a process has too many threads to perform the requested action. For example, assignment of a primary token may only be performed when a process has zero or one threads.
        /// </summary>
        TooManyThreads = 0x00000235,

        /// <summary>
        /// An attempt was made to operate on a thread within a specific process, but the thread specified is not in the process specified.
        /// </summary>
        ThreadNotInProcess = 0x00000236,

        /// <summary>
        /// Page file quota was exceeded.
        /// </summary>
        PagefileQuotaExceeded = 0x00000237,

        /// <summary>
        /// The Netlogon service cannot start because another Netlogon service running in the domain conflicts with the specified role.
        /// </summary>
        LogonServerConflict = 0x00000238,

        /// <summary>
        /// The SAM database on a Windows Server is significantly out of synchronization with the copy on the Domain Controller. A complete synchronization is required.
        /// </summary>
        SynchronizationRequired = 0x00000239,

        /// <summary>
        /// The NtCreateFile API failed. This error should never be returned to an application, it is a place holder for the Windows Lan Manager Redirector to use in its internal error mapping routines.
        /// </summary>
        NetOpenFailed = 0x0000023A,

        /// <summary>
        /// {Privilege Failed}
        /// The I/O permissions for the process could not be changed.
        /// </summary>
        IoPrivilegeFailed = 0x0000023B,

        /// <summary>
        /// {Application Exit by CTRL+C}
        /// The application terminated as a result of a CTRL+C.
        /// </summary>
        ControlCExit = 0x0000023C,

        /// <summary>
        /// {Missing System File}
        /// The required system file %hs is bad or missing.
        /// </summary>
        MissingSystemfile = 0x0000023D,

        /// <summary>
        /// {Application Error}
        /// The exception %s (0x%08lx) occurred in the application at location 0x%08lx.
        /// </summary>
        UnhandledException = 0x0000023E,

        /// <summary>
        /// {Application Error}
        /// The application was unable to start correctly (0x%lx). Click OK to close the application.
        /// </summary>
        AppInitFailure = 0x0000023F,

        /// <summary>
        /// {Unable to Create Paging File}
        /// The creation of the paging file %hs failed (%lx). The requested size was %ld.
        /// </summary>
        PagefileCreateFailed = 0x00000240,

        /// <summary>
        /// Windows cannot verify the digital signature for this file. A recent hardware or software change might have installed a file that is signed incorrectly or damaged, or that might be malicious software from an unknown source.
        /// </summary>
        InvalidImageHash = 0x00000241,

        /// <summary>
        /// {No Paging File Specified}
        /// No paging file was specified in the system configuration.
        /// </summary>
        NoPagefile = 0x00000242,

        /// <summary>
        /// {EXCEPTION}
        /// A real-mode application issued a floating-point instruction and floating-point hardware is not present.
        /// </summary>
        IllegalFloatContext = 0x00000243,

        /// <summary>
        /// An event pair synchronization operation was performed using the thread specific client/server event pair object, but no event pair object was associated with the thread.
        /// </summary>
        NoEventPair = 0x00000244,

        /// <summary>
        /// A Windows Server has an incorrect configuration.
        /// </summary>
        DomainCtrlrConfigError = 0x00000245,

        /// <summary>
        /// An illegal character was encountered. For a multi-byte character set this includes a lead byte without a succeeding trail byte. For the Unicode character set this includes the characters 0xFFFF and 0xFFFE.
        /// </summary>
        IllegalCharacter = 0x00000246,

        /// <summary>
        /// The Unicode character is not defined in the Unicode character set installed on the system.
        /// </summary>
        UndefinedCharacter = 0x00000247,

        /// <summary>
        /// The paging file cannot be created on a floppy diskette.
        /// </summary>
        FloppyVolume = 0x00000248,

        /// <summary>
        /// This operation is only allowed for the Primary Domain Controller of the domain.
        /// </summary>
        BackupController = 0x0000024A,

        /// <summary>
        /// An attempt was made to acquire a mutant such that its maximum count would have been exceeded.
        /// </summary>
        MutantLimitExceeded = 0x0000024B,

        /// <summary>
        /// A volume has been accessed for which a file system driver is required that has not yet been loaded.
        /// </summary>
        FsDriverRequired = 0x0000024C,

        /// <summary>
        /// {Registry File Failure}
        /// The registry cannot load the hive (file):
        /// %hs
        /// or its log or alternate.
        /// It is corrupt, absent, or not writable.
        /// </summary>
        CannotLoadRegistryFile = 0x0000024D,

        /// <summary>
        /// {Unexpected Failure in DebugActiveProcess}
        /// An unexpected failure occurred while processing a DebugActiveProcess API request. You may choose OK to terminate the process, or Cancel to ignore the error.
        /// </summary>
        DebugAttachFailed = 0x0000024E,

        /// <summary>
        /// {Fatal System Error}
        /// The %hs system process terminated unexpectedly with a status of 0x%08x (0x%08x 0x%08x).
        /// The system has been shut down.
        /// </summary>
        SystemProcessTerminated = 0x0000024F,

        /// <summary>
        /// {Data Not Accepted}
        /// The TDI client could not handle the data received during an indication.
        /// </summary>
        DataNotAccepted = 0x00000250,

        /// <summary>
        /// NTVDM encountered a hard error.
        /// </summary>
        VdmHardError = 0x00000251,

        /// <summary>
        /// {Cancel Timeout}
        /// The driver %hs failed to complete a cancelled I/O request in the allotted time.
        /// </summary>
        DriverCancelTimeout = 0x00000252,

        /// <summary>
        /// {Reply Message Mismatch}
        /// An attempt was made to reply to an LPC message, but the thread specified by the client ID in the message was not waiting on that message.
        /// </summary>
        ReplyMessageMismatch = 0x00000253,

        /// <summary>
        /// {Delayed Write Failed}
        /// Windows was unable to save all the data for the file %hs. The data has been lost.
        /// This error may be caused by a failure of your computer hardware or network connection. Please try to save this file elsewhere.
        /// </summary>
        LostWritebehindData = 0x00000254,

        /// <summary>
        /// The stream is not a tiny stream.
        /// </summary>
        NotTinyStream = 0x00000256,

        /// <summary>
        /// The request must be handled by the stack overflow code.
        /// </summary>
        StackOverflowRead = 0x00000257,

        /// <summary>
        /// Internal OFS status codes indicating how an allocation operation is handled. Either it is retried after the containing onode is moved or the extent stream is converted to a large stream.
        /// </summary>
        ConvertToLarge = 0x00000258,

        /// <summary>
        /// The attempt to find the object found an object matching by ID on the volume but it is out of the scope of the handle used for the operation.
        /// </summary>
        FoundOutOfScope = 0x00000259,

        /// <summary>
        /// The bucket array must be grown. Retry transaction after doing so.
        /// </summary>
        AllocateBucket = 0x0000025A,

        /// <summary>
        /// The user/kernel marshalling buffer has overflowed.
        /// </summary>
        MarshallOverflow = 0x0000025B,

        /// <summary>
        /// The supplied variant structure contains invalid data.
        /// </summary>
        InvalidVariant = 0x0000025C,

        /// <summary>
        /// The specified buffer contains ill-formed data.
        /// </summary>
        BadCompressionBuffer = 0x0000025D,

        /// <summary>
        /// {Audit Failed}
        /// An attempt to generate a security audit failed.
        /// </summary>
        AuditFailed = 0x0000025E,

        /// <summary>
        /// The timer resolution was not previously set by the current process.
        /// </summary>
        TimerResolutionNotSet = 0x0000025F,

        /// <summary>
        /// There is insufficient account information to log you on.
        /// </summary>
        InsufficientLogonInfo = 0x00000260,

        /// <summary>
        /// {Invalid DLL Entrypoint}
        /// The dynamic link library %hs is not written correctly. The stack pointer has been left in an inconsistent state.
        /// The entrypoint should be declared as WINAPI or STDCALL. Select YES to fail the DLL load. Select NO to continue execution. Selecting NO may cause the application to operate incorrectly.
        /// </summary>
        BadDllEntrypoint = 0x00000261,

        /// <summary>
        /// {Invalid Service Callback Entrypoint}
        /// The %hs service is not written correctly. The stack pointer has been left in an inconsistent state.
        /// The callback entrypoint should be declared as WINAPI or STDCALL. Selecting OK will cause the service to continue operation. However, the service process may operate incorrectly.
        /// </summary>
        BadServiceEntrypoint = 0x00000262,

        /// <summary>
        /// There is an IP address conflict with another system on the network
        /// </summary>
        IpAddressConflict1 = 0x00000263,

        /// <summary>
        /// There is an IP address conflict with another system on the network
        /// </summary>
        IpAddressConflict2 = 0x00000264,

        /// <summary>
        /// {Low On Registry Space}
        /// The system has reached the maximum size allowed for the system part of the registry. Additional storage requests will be ignored.
        /// </summary>
        RegistryQuotaLimit = 0x00000265,

        /// <summary>
        /// A callback return system service cannot be executed when no callback is active.
        /// </summary>
        NoCallbackActive = 0x00000266,

        /// <summary>
        /// The password provided is too short to meet the policy of your user account.
        /// Please choose a longer password.
        /// </summary>
        PwdTooShort = 0x00000267,

        /// <summary>
        /// The policy of your user account does not allow you to change passwords too frequently.
        /// This is done to prevent users from changing back to a familiar, but potentially discovered, password.
        /// If you feel your password has been compromised then please contact your administrator immediately to have a new one assigned.
        /// </summary>
        PwdTooRecent = 0x00000268,

        /// <summary>
        /// You have attempted to change your password to one that you have used in the past.
        /// The policy of your user account does not allow this. Please select a password that you have not previously used.
        /// </summary>
        PwdHistoryConflict = 0x00000269,

        /// <summary>
        /// The specified compression format is unsupported.
        /// </summary>
        UnsupportedCompression = 0x0000026A,

        /// <summary>
        /// The specified hardware profile configuration is invalid.
        /// </summary>
        InvalidHwProfile = 0x0000026B,

        /// <summary>
        /// The specified quota list is internally inconsistent with its descriptor.
        /// </summary>
        QuotaListInconsistent = 0x0000026D,

        /// <summary>
        /// {Windows Evaluation Notification}
        /// The evaluation period for this installation of Windows has expired. This system will shutdown in 1 hour. To restore access to this installation of Windows, please upgrade this installation using a licensed distribution of this product.
        /// </summary>
        EvaluationExpiration = 0x0000026E,

        /// <summary>
        /// {Illegal System DLL Relocation}
        /// The system DLL %hs was relocated in memory. The application will not run properly.
        /// The relocation occurred because the DLL %hs occupied an address range reserved for Windows system DLLs. The vendor supplying the DLL should be contacted for a new DLL.
        /// </summary>
        IllegalDllRelocation = 0x0000026F,

        /// <summary>
        /// {DLL Initialization Failed}
        /// The application failed to initialize because the window station is shutting down.
        /// </summary>
        DllInitFailedLogoff = 0x00000270,

        /// <summary>
        /// The validation process needs to continue on to the next step.
        /// </summary>
        ValidateContinue = 0x00000271,

        /// <summary>
        /// There are no more matches for the current index enumeration.
        /// </summary>
        NoMoreMatches = 0x00000272,

        /// <summary>
        /// The range could not be added to the range list because of a conflict.
        /// </summary>
        RangeListConflict = 0x00000273,

        /// <summary>
        /// The server process is running under a SID different than that required by client.
        /// </summary>
        ServerSidMismatch = 0x00000274,

        /// <summary>
        /// A group marked use for deny only cannot be enabled.
        /// </summary>
        CantEnableDenyOnly = 0x00000275,

        /// <summary>
        /// {EXCEPTION}
        /// Multiple floating point faults.
        /// </summary>
        FloatMultipleFaults = 0x00000276,

        /// <summary>
        /// {EXCEPTION}
        /// Multiple floating point traps.
        /// </summary>
        FloatMultipleTraps = 0x00000277,

        /// <summary>
        /// The requested interface is not supported.
        /// </summary>
        Nointerface = 0x00000278,

        /// <summary>
        /// {System Standby Failed}
        /// The driver %hs does not support standby mode. Updating this driver may allow the system to go to standby mode.
        /// </summary>
        DriverFailedSleep = 0x00000279,

        /// <summary>
        /// The system file %1 has become corrupt and has been replaced.
        /// </summary>
        CorruptSystemFile = 0x0000027A,

        /// <summary>
        /// {Virtual Memory Minimum Too Low}
        /// Your system is low on virtual memory. Windows is increasing the size of your virtual memory paging file.
        /// During this process, memory requests for some applications may be denied. For more information, see Help.
        /// </summary>
        CommitmentMinimum = 0x0000027B,

        /// <summary>
        /// A device was removed so enumeration must be restarted.
        /// </summary>
        PnpRestartEnumeration = 0x0000027C,

        /// <summary>
        /// Device will not start without a reboot.
        /// </summary>
        PnpRebootRequired = 0x0000027E,

        /// <summary>
        /// There is not enough power to complete the requested operation.
        /// </summary>
        InsufficientPower = 0x0000027F,

        /// <summary>
        /// ERROR_MULTIPLE_FAULT_VIOLATION
        /// </summary>
        MultipleFaultViolation = 0x00000280,

        /// <summary>
        /// The system is in the process of shutting down.
        /// </summary>
        SystemShutdown = 0x00000281,

        /// <summary>
        /// An attempt to remove a processes DebugPort was made, but a port was not already associated with the process.
        /// </summary>
        PortNotSet = 0x00000282,

        /// <summary>
        /// This version of Windows is not compatible with the behavior version of directory forest, domain or domain controller.
        /// </summary>
        DsVersionCheckFailure = 0x00000283,

        /// <summary>
        /// The specified range could not be found in the range list.
        /// </summary>
        RangeNotFound = 0x00000284,

        /// <summary>
        /// The driver was not loaded because the system is booting into safe mode.
        /// </summary>
        NotSafeModeDriver = 0x00000286,

        /// <summary>
        /// The driver was not loaded because it failed its initialization call.
        /// </summary>
        FailedDriverEntry = 0x00000287,

        /// <summary>
        /// The "%hs" encountered an error while applying power or reading the device configuration.
        /// This may be caused by a failure of your hardware or by a poor connection.
        /// </summary>
        DeviceEnumerationError = 0x00000288,

        /// <summary>
        /// The create operation failed because the name contained at least one mount point which resolves to a volume to which the specified device object is not attached.
        /// </summary>
        MountPointNotResolved = 0x00000289,

        /// <summary>
        /// A Machine Check Error has occurred. Please check the system eventlog for additional information.
        /// </summary>
        McaOccured = 0x0000028B,

        /// <summary>
        /// There was error [%2] processing the driver database.
        /// </summary>
        DriverDatabaseError = 0x0000028C,

        /// <summary>
        /// System hive size has exceeded its limit.
        /// </summary>
        SystemHiveTooLarge = 0x0000028D,

        /// <summary>
        /// {Volume Shadow Copy Service}
        /// Please wait while the Volume Shadow Copy Service prepares volume %hs for hibernation.
        /// </summary>
        VolsnapPrepareHibernate = 0x0000028F,

        /// <summary>
        /// The system has failed to hibernate (The error code is %hs). Hibernation will be disabled until the system is restarted.
        /// </summary>
        HibernationFailure = 0x00000290,

        /// <summary>
        /// The password provided is too long to meet the policy of your user account.
        /// Please choose a shorter password.
        /// </summary>
        PwdTooLong = 0x00000291,

        /// <summary>
        /// The requested operation could not be completed due to a file system limitation
        /// </summary>
        FileSystemLimitation = 0x00000299,

        /// <summary>
        /// An assertion failure has occurred.
        /// </summary>
        AssertionFailure = 0x0000029C,

        /// <summary>
        /// An error occurred in the ACPI subsystem.
        /// </summary>
        AcpiError = 0x0000029D,

        /// <summary>
        /// WOW Assertion Error.
        /// </summary>
        WowAssertion = 0x0000029E,

        /// <summary>
        /// A device is missing in the system BIOS MPS table. This device will not be used.
        /// Please contact your system vendor for system BIOS update.
        /// </summary>
        PnpBadMpsTable = 0x0000029F,

        /// <summary>
        /// A translator failed to translate resources.
        /// </summary>
        PnpTranslationFailed = 0x000002A0,

        /// <summary>
        /// Driver %2 returned invalid ID for a child device (%3).
        /// </summary>
        PnpInvalidId = 0x000002A2,

        /// <summary>
        /// {Kernel Debugger Awakened}
        /// the system debugger was awakened by an interrupt.
        /// </summary>
        WakeSystemDebugger = 0x000002A3,

        /// <summary>
        /// {Handles Closed}
        /// Handles to objects have been automatically closed as a result of the requested operation.
        /// </summary>
        HandlesClosed = 0x000002A4,

        /// <summary>
        /// {Too Much Information}
        /// The specified access control list (ACL) contained more information than was expected.
        /// </summary>
        ExtraneousInformation = 0x000002A5,

        /// <summary>
        /// This warning level status indicates that the transaction state already exists for the registry sub-tree, but that a transaction commit was previously aborted.
        /// The commit has NOT been completed, but has not been rolled back either (so it may still be committed if desired).
        /// </summary>
        RxactCommitNecessary = 0x000002A6,

        /// <summary>
        /// {Media Changed}
        /// The media may have changed.
        /// </summary>
        MediaCheck = 0x000002A7,

        /// <summary>
        /// {GUID Substitution}
        /// During the translation of a global identifier (GUID) to a Windows security ID (SID), no administratively-defined GUID prefix was found.
        /// A substitute prefix was used, which will not compromise system security. However, this may provide a more restrictive access than intended.
        /// </summary>
        GuidSubstitutionMade = 0x000002A8,

        /// <summary>
        /// The create operation stopped after reaching a symbolic link
        /// </summary>
        StoppedOnSymlink = 0x000002A9,

        /// <summary>
        /// A long jump has been executed.
        /// </summary>
        Longjump = 0x000002AA,

        /// <summary>
        /// The Plug and Play query operation was not successful.
        /// </summary>
        PlugplayQueryVetoed = 0x000002AB,

        /// <summary>
        /// A frame consolidation has been executed.
        /// </summary>
        UnwindConsolidate = 0x000002AC,

        /// <summary>
        /// {Registry Hive Recovered}
        /// Registry hive (file):
        /// %hs
        /// was corrupted and it has been recovered. Some data might have been lost.
        /// </summary>
        RegistryHiveRecovered = 0x000002AD,

        /// <summary>
        /// The application is attempting to run executable code from the module %hs. This may be insecure. An alternative, %hs, is available. Should the application use the secure module %hs?
        /// </summary>
        DllMightBeInsecure = 0x000002AE,

        /// <summary>
        /// The application is loading executable code from the module %hs. This is secure, but may be incompatible with previous releases of the operating system. An alternative, %hs, is available. Should the application use the secure module %hs?
        /// </summary>
        DllMightBeIncompatible = 0x000002AF,

        /// <summary>
        /// Debugger did not handle the exception.
        /// </summary>
        DbgExceptionNotHandled = 0x000002B0,

        /// <summary>
        /// Debugger will reply later.
        /// </summary>
        DbgReplyLater = 0x000002B1,

        /// <summary>
        /// Debugger terminated thread.
        /// </summary>
        DbgTerminateThread = 0x000002B3,

        /// <summary>
        /// Debugger terminated process.
        /// </summary>
        DbgTerminateProcess = 0x000002B4,

        /// <summary>
        /// Debugger got control C.
        /// </summary>
        DbgControlC = 0x000002B5,

        /// <summary>
        /// Debugger printed exception on control C.
        /// </summary>
        DbgPrintexceptionC = 0x000002B6,

        /// <summary>
        /// Debugger received RIP exception.
        /// </summary>
        DbgRipexception = 0x000002B7,

        /// <summary>
        /// Debugger received control break.
        /// </summary>
        DbgControlBreak = 0x000002B8,

        /// <summary>
        /// Debugger command communication exception.
        /// </summary>
        DbgCommandException = 0x000002B9,

        /// <summary>
        /// {Object Exists}
        /// An attempt was made to create an object and the object name already existed.
        /// </summary>
        ObjectNameExists = 0x000002BA,

        /// <summary>
        /// {Thread Suspended}
        /// A thread termination occurred while the thread was suspended. The thread was resumed, and termination proceeded.
        /// </summary>
        ThreadWasSuspended = 0x000002BB,

        /// <summary>
        /// {Image Relocated}
        /// An image file could not be mapped at the address specified in the image file. Local fixups must be performed on this image.
        /// </summary>
        ImageNotAtBase = 0x000002BC,

        /// <summary>
        /// This informational level status indicates that a specified registry sub-tree transaction state did not yet exist and had to be created.
        /// </summary>
        RxactStateCreated = 0x000002BD,

        /// <summary>
        /// {Segment Load}
        /// A virtual DOS machine (VDM) is loading, unloading, or moving an MS-DOS or Win16 program segment image.
        /// An exception is raised so a debugger can load, unload or track symbols and breakpoints within these 16-bit segments.
        /// </summary>
        SegmentNotification = 0x000002BE,

        /// <summary>
        /// {Invalid Current Directory}
        /// The process cannot switch to the startup current directory %hs.
        /// Select OK to set current directory to %hs, or select CANCEL to exit.
        /// </summary>
        BadCurrentDirectory = 0x000002BF,

        /// <summary>
        /// {Redundant Write}
        /// To satisfy a write request, the NT fault-tolerant file system successfully wrote a redundant copy of the information.
        /// This was done because the file system encountered a failure on a member of the fault-tolerant volume, but was not able to reassign the failing area of the device.
        /// </summary>
        FtWriteRecovery = 0x000002C1,

        /// <summary>
        /// {Partial Data Received}
        /// The network transport returned partial data to its client. The remaining data will be sent later.
        /// </summary>
        ReceivePartial = 0x000002C3,

        /// <summary>
        /// {Expedited Data Received}
        /// The network transport returned data to its client that was marked as expedited by the remote system.
        /// </summary>
        ReceiveExpedited = 0x000002C4,

        /// <summary>
        /// {Partial Expedited Data Received}
        /// The network transport returned partial data to its client and this data was marked as expedited by the remote system. The remaining data will be sent later.
        /// </summary>
        ReceivePartialExpedited = 0x000002C5,

        /// <summary>
        /// {TDI Event Done}
        /// The TDI indication has completed successfully.
        /// </summary>
        EventDone = 0x000002C6,

        /// <summary>
        /// {TDI Event Pending}
        /// The TDI indication has entered the pending state.
        /// </summary>
        EventPending = 0x000002C7,

        /// <summary>
        /// Checking file system on %wZ
        /// </summary>
        CheckingFileSystem = 0x000002C8,

        /// <summary>
        /// {Fatal Application Exit}
        /// %hs
        /// </summary>
        FatalAppExit = 0x000002C9,

        /// <summary>
        /// The specified registry key is referenced by a predefined handle.
        /// </summary>
        PredefinedHandle = 0x000002CA,

        /// <summary>
        /// {Page Unlocked}
        /// The page protection of a locked page was changed to 'No Access' and the page was unlocked from memory and from the process.
        /// </summary>
        WasUnlocked = 0x000002CB,

        /// <summary>
        /// %hs
        /// </summary>
        ServiceNotification = 0x000002CC,

        /// <summary>
        /// {Page Locked}
        /// One of the pages to lock was already locked.
        /// </summary>
        WasLocked = 0x000002CD,

        /// <summary>
        /// Application popup: %1 : %2
        /// </summary>
        LogHardError = 0x000002CE,

        /// <summary>
        /// ERROR_ALREADY_WIN32
        /// </summary>
        AlreadyWin32 = 0x000002CF,

        /// <summary>
        /// A yield execution was performed and no thread was available to run.
        /// </summary>
        NoYieldPerformed = 0x000002D1,

        /// <summary>
        /// The resumable flag to a timer API was ignored.
        /// </summary>
        TimerResumeIgnored = 0x000002D2,

        /// <summary>
        /// The arbiter has deferred arbitration of these resources to its parent
        /// </summary>
        ArbitrationUnhandled = 0x000002D3,

        /// <summary>
        /// The inserted CardBus device cannot be started because of a configuration error on "%hs".
        /// </summary>
        CardbusNotSupported = 0x000002D4,

        /// <summary>
        /// The CPUs in this multiprocessor system are not all the same revision level. To use all processors the operating system restricts itself to the features of the least capable processor in the system. Should problems occur with this system, contact the CPU manufacturer to see if this mix of processors is supported.
        /// </summary>
        MpProcessorMismatch = 0x000002D5,

        /// <summary>
        /// The system was put into hibernation.
        /// </summary>
        Hibernated = 0x000002D6,

        /// <summary>
        /// The system was resumed from hibernation.
        /// </summary>
        ResumeHibernation = 0x000002D7,

        /// <summary>
        /// Windows has detected that the system firmware (BIOS) was updated [previous firmware date = %2, current firmware date %3].
        /// </summary>
        FirmwareUpdated = 0x000002D8,

        /// <summary>
        /// The system has awoken
        /// </summary>
        WakeSystem = 0x000002DA,

        /// <summary>
        /// ERROR_WAIT_1
        /// </summary>
        Wait1 = 0x000002DB,

        /// <summary>
        /// ERROR_WAIT_2
        /// </summary>
        Wait2 = 0x000002DC,

        /// <summary>
        /// ERROR_WAIT_3
        /// </summary>
        Wait3 = 0x000002DD,

        /// <summary>
        /// ERROR_WAIT_63
        /// </summary>
        Wait63 = 0x000002DE,

        /// <summary>
        /// ERROR_ABANDONED_WAIT_0
        /// </summary>
        AbandonedWait0 = 0x000002DF,

        /// <summary>
        /// ERROR_ABANDONED_WAIT_63
        /// </summary>
        AbandonedWait63 = 0x000002E0,

        /// <summary>
        /// ERROR_USER_APC
        /// </summary>
        UserApc = 0x000002E1,

        /// <summary>
        /// ERROR_KERNEL_APC
        /// </summary>
        KernelApc = 0x000002E2,

        /// <summary>
        /// ERROR_ALERTED
        /// </summary>
        Alerted = 0x000002E3,

        /// <summary>
        /// The requested operation requires elevation.
        /// </summary>
        ElevationRequired = 0x000002E4,

        /// <summary>
        /// A reparse should be performed by the Object Manager since the name of the file resulted in a symbolic link.
        /// </summary>
        Reparse = 0x000002E5,

        /// <summary>
        /// An open/create operation completed while an oplock break is underway.
        /// </summary>
        OplockBreakInProgress = 0x000002E6,

        /// <summary>
        /// A new volume has been mounted by a file system.
        /// </summary>
        VolumeMounted = 0x000002E7,

        /// <summary>
        /// This success level status indicates that the transaction state already exists for the registry sub-tree, but that a transaction commit was previously aborted.
        /// The commit has now been completed.
        /// </summary>
        RxactCommitted = 0x000002E8,

        /// <summary>
        /// This indicates that a notify change request has been completed due to closing the handle which made the notify change request.
        /// </summary>
        NotifyCleanup = 0x000002E9,

        /// <summary>
        /// Page fault was a transition fault.
        /// </summary>
        PageFaultTransition = 0x000002EB,

        /// <summary>
        /// Page fault was a demand zero fault.
        /// </summary>
        PageFaultDemandZero = 0x000002EC,

        /// <summary>
        /// Page fault was a demand zero fault.
        /// </summary>
        PageFaultCopyOnWrite = 0x000002ED,

        /// <summary>
        /// Page fault was a demand zero fault.
        /// </summary>
        PageFaultGuardPage = 0x000002EE,

        /// <summary>
        /// Page fault was satisfied by reading from a secondary storage device.
        /// </summary>
        PageFaultPagingFile = 0x000002EF,

        /// <summary>
        /// Cached page was locked during operation.
        /// </summary>
        CachePageLocked = 0x000002F0,

        /// <summary>
        /// Crash dump exists in paging file.
        /// </summary>
        CrashDump = 0x000002F1,

        /// <summary>
        /// Specified buffer contains all zeros.
        /// </summary>
        BufferAllZeros = 0x000002F2,

        /// <summary>
        /// A reparse should be performed by the Object Manager since the name of the file resulted in a symbolic link.
        /// </summary>
        ReparseObject = 0x000002F3,

        /// <summary>
        /// The translator has translated these resources into the global space and no further translations should be performed.
        /// </summary>
        TranslationComplete = 0x000002F5,

        /// <summary>
        /// A process being terminated has no threads to terminate.
        /// </summary>
        NothingToTerminate = 0x000002F6,

        /// <summary>
        /// The specified process is not part of a job.
        /// </summary>
        ProcessNotInJob = 0x000002F7,

        /// <summary>
        /// The specified process is part of a job.
        /// </summary>
        ProcessInJob = 0x000002F8,

        /// <summary>
        /// {Volume Shadow Copy Service}
        /// The system is now ready for hibernation.
        /// </summary>
        VolsnapHibernateReady = 0x000002F9,

        /// <summary>
        /// The specified interrupt vector is still connected.
        /// </summary>
        InterruptStillConnected = 0x000002FC,

        /// <summary>
        /// An operation is blocked waiting for an oplock.
        /// </summary>
        WaitForOplock = 0x000002FD,

        /// <summary>
        /// Debugger handled exception
        /// </summary>
        DbgExceptionHandled = 0x000002FE,

        /// <summary>
        /// Debugger continued
        /// </summary>
        DbgContinue = 0x000002FF,

        /// <summary>
        /// An exception occurred in a user mode callback and the kernel callback frame should be removed.
        /// </summary>
        CallbackPopStack = 0x00000300,

        /// <summary>
        /// Compression is disabled for this volume.
        /// </summary>
        CompressionDisabled = 0x00000301,

        /// <summary>
        /// The data provider cannot fetch backwards through a result set.
        /// </summary>
        Cantfetchbackwards = 0x00000302,

        /// <summary>
        /// The data provider cannot scroll backwards through a result set.
        /// </summary>
        Cantscrollbackwards = 0x00000303,

        /// <summary>
        /// The data provider requires that previously fetched data is released before asking for more data.
        /// </summary>
        Rowsnotreleased = 0x00000304,

        /// <summary>
        /// The data provider was not able to interpret the flags set for a column binding in an accessor.
        /// </summary>
        BadAccessorFlags = 0x00000305,

        /// <summary>
        /// One or more errors occurred while processing the request.
        /// </summary>
        ErrorsEncountered = 0x00000306,

        /// <summary>
        /// The implementation is not capable of performing the request.
        /// </summary>
        NotCapable = 0x00000307,

        /// <summary>
        /// The client of a component requested an operation which is not valid given the state of the component instance.
        /// </summary>
        RequestOutOfSequence = 0x00000308,

        /// <summary>
        /// A version number could not be parsed.
        /// </summary>
        VersionParseError = 0x00000309,

        /// <summary>
        /// The iterator's start position is invalid.
        /// </summary>
        Badstartposition = 0x0000030A,

        /// <summary>
        /// The hardware has reported an uncorrectable memory error.
        /// </summary>
        MemoryHardware = 0x0000030B,

        /// <summary>
        /// The attempted operation required self healing to be enabled.
        /// </summary>
        DiskRepairDisabled = 0x0000030C,

        /// <summary>
        /// A thread is getting dispatched with MCA EXCEPTION because of MCA.
        /// </summary>
        McaException = 0x00000310,

        /// <summary>
        /// Access to %1 is monitored by policy rule %2.
        /// </summary>
        AccessAuditByPolicy = 0x00000311,

        /// <summary>
        /// A valid hibernation file has been invalidated and should be abandoned.
        /// </summary>
        AbandonHiberfile = 0x00000313,

        /// <summary>
        /// The resources required for this device conflict with the MCFG table.
        /// </summary>
        BadMcfgTable = 0x00000317,

        /// <summary>
        /// The volume repair could not be performed while it is online.
        /// Please schedule to take the volume offline so that it can be repaired.
        /// </summary>
        DiskRepairRedirected = 0x00000318,

        /// <summary>
        /// The volume repair was not successful.
        /// </summary>
        DiskRepairUnsuccessful = 0x00000319,

        /// <summary>
        /// One of the volume corruption logs is full. Further corruptions that may be detected won't be logged.
        /// </summary>
        CorruptLogOverfull = 0x0000031A,

        /// <summary>
        /// One of the volume corruption logs is internally corrupted and needs to be recreated. The volume may contain undetected corruptions and must be scanned.
        /// </summary>
        CorruptLogCorrupted = 0x0000031B,

        /// <summary>
        /// One of the volume corruption logs is unavailable for being operated on.
        /// </summary>
        CorruptLogUnavailable = 0x0000031C,

        /// <summary>
        /// One of the volume corruption logs was deleted while still having corruption records in them. The volume contains detected corruptions and must be scanned.
        /// </summary>
        CorruptLogDeletedFull = 0x0000031D,

        /// <summary>
        /// One of the volume corruption logs was cleared by chkdsk and no longer contains real corruptions.
        /// </summary>
        CorruptLogCleared = 0x0000031E,

        /// <summary>
        /// Orphaned files exist on the volume but could not be recovered because no more new names could be created in the recovery directory. Files must be moved from the recovery directory.
        /// </summary>
        OrphanNameExhausted = 0x0000031F,

        /// <summary>
        /// The operation did not complete successfully because it would cause an oplock to be broken. The caller has requested that existing oplocks not be broken.
        /// </summary>
        CannotBreakOplock = 0x00000322,

        /// <summary>
        /// The handle with which this oplock was associated has been closed.  The oplock is now broken.
        /// </summary>
        OplockHandleClosed = 0x00000323,

        /// <summary>
        /// The specified access control entry (ACE) does not contain a condition.
        /// </summary>
        NoAceCondition = 0x00000324,

        /// <summary>
        /// The specified access control entry (ACE) contains an invalid condition.
        /// </summary>
        InvalidAceCondition = 0x00000325,

        /// <summary>
        /// Access to the specified file handle has been revoked.
        /// </summary>
        FileHandleRevoked = 0x00000326,

        /// <summary>
        /// {Image Relocated}
        /// An image file was mapped at a different address from the one specified in the image file but fixups will still be automatically performed on the image.
        /// </summary>
        ImageAtDifferentBase = 0x00000327,

        /// <summary>
        /// The read or write operation to an encrypted file could not be completed because the file has not been opened for data access.
        /// </summary>
        EncryptedIoNotPossible = 0x00000328,

        /// <summary>
        /// Access to the extended attribute was denied.
        /// </summary>
        EaAccessDenied = 0x000003E2,

        /// <summary>
        /// The I/O operation has been aborted because of either a thread exit or an application request.
        /// </summary>
        OperationAborted = 0x000003E3,

        /// <summary>
        /// Overlapped I/O event is not in a signaled state.
        /// </summary>
        IoIncomplete = 0x000003E4,

        /// <summary>
        /// Overlapped I/O operation is in progress.
        /// </summary>
        IoPending = 0x000003E5,

        /// <summary>
        /// Invalid access to memory location.
        /// </summary>
        Noaccess = 0x000003E6,

        /// <summary>
        /// Error performing inpage operation.
        /// </summary>
        Swaperror = 0x000003E7,

        /// <summary>
        /// Recursion too deep; the stack overflowed.
        /// </summary>
        StackOverflow = 0x000003E9,

        /// <summary>
        /// The window cannot act on the sent message.
        /// </summary>
        InvalidMessage = 0x000003EA,

        /// <summary>
        /// Cannot complete this function.
        /// </summary>
        CanNotComplete = 0x000003EB,

        /// <summary>
        /// Invalid flags.
        /// </summary>
        InvalidFlags = 0x000003EC,

        /// <summary>
        /// The volume does not contain a recognized file system.
        /// Please make sure that all required file system drivers are loaded and that the volume is not corrupted.
        /// </summary>
        UnrecognizedVolume = 0x000003ED,

        /// <summary>
        /// The volume for a file has been externally altered so that the opened file is no longer valid.
        /// </summary>
        FileInvalid = 0x000003EE,

        /// <summary>
        /// The requested operation cannot be performed in full-screen mode.
        /// </summary>
        FullscreenMode = 0x000003EF,

        /// <summary>
        /// An attempt was made to reference a token that does not exist.
        /// </summary>
        NoToken = 0x000003F0,

        /// <summary>
        /// The configuration registry database is corrupt.
        /// </summary>
        Baddb = 0x000003F1,

        /// <summary>
        /// The configuration registry key is invalid.
        /// </summary>
        Badkey = 0x000003F2,

        /// <summary>
        /// The configuration registry key could not be opened.
        /// </summary>
        Cantopen = 0x000003F3,

        /// <summary>
        /// The configuration registry key could not be read.
        /// </summary>
        Cantread = 0x000003F4,

        /// <summary>
        /// The configuration registry key could not be written.
        /// </summary>
        Cantwrite = 0x000003F5,

        /// <summary>
        /// One of the files in the registry database had to be recovered by use of a log or alternate copy. The recovery was successful.
        /// </summary>
        RegistryRecovered = 0x000003F6,

        /// <summary>
        /// The registry is corrupted. The structure of one of the files containing registry data is corrupted, or the system's memory image of the file is corrupted, or the file could not be recovered because the alternate copy or log was absent or corrupted.
        /// </summary>
        RegistryCorrupt = 0x000003F7,

        /// <summary>
        /// An I/O operation initiated by the registry failed unrecoverably. The registry could not read in, or write out, or flush, one of the files that contain the system's image of the registry.
        /// </summary>
        RegistryIoFailed = 0x000003F8,

        /// <summary>
        /// The system has attempted to load or restore a file into the registry, but the specified file is not in a registry file format.
        /// </summary>
        NotRegistryFile = 0x000003F9,

        /// <summary>
        /// Illegal operation attempted on a registry key that has been marked for deletion.
        /// </summary>
        KeyDeleted = 0x000003FA,

        /// <summary>
        /// System could not allocate the required space in a registry log.
        /// </summary>
        NoLogSpace = 0x000003FB,

        /// <summary>
        /// Cannot create a symbolic link in a registry key that already has subkeys or values.
        /// </summary>
        KeyHasChildren = 0x000003FC,

        /// <summary>
        /// Cannot create a stable subkey under a volatile parent key.
        /// </summary>
        ChildMustBeVolatile = 0x000003FD,

        /// <summary>
        /// A notify change request is being completed and the information is not being returned in the caller's buffer. The caller now needs to enumerate the files to find the changes.
        /// </summary>
        NotifyEnumDir = 0x000003FE,

        /// <summary>
        /// The requested control is not valid for this service.
        /// </summary>
        InvalidServiceControl = 0x0000041C,

        /// <summary>
        /// The service did not respond to the start or control request in a timely fashion.
        /// </summary>
        ServiceRequestTimeout = 0x0000041D,

        /// <summary>
        /// A thread could not be created for the service.
        /// </summary>
        ServiceNoThread = 0x0000041E,

        /// <summary>
        /// The service database is locked.
        /// </summary>
        ServiceDatabaseLocked = 0x0000041F,

        /// <summary>
        /// An instance of the service is already running.
        /// </summary>
        ServiceAlreadyRunning = 0x00000420,

        /// <summary>
        /// The account name is invalid or does not exist, or the password is invalid for the account name specified.
        /// </summary>
        InvalidServiceAccount = 0x00000421,

        /// <summary>
        /// The service cannot be started, either because it is disabled or because it has no enabled devices associated with it.
        /// </summary>
        ServiceDisabled = 0x00000422,

        /// <summary>
        /// Circular service dependency was specified.
        /// </summary>
        CircularDependency = 0x00000423,

        /// <summary>
        /// The specified service does not exist as an installed service.
        /// </summary>
        ServiceDoesNotExist = 0x00000424,

        /// <summary>
        /// The service has not been started.
        /// </summary>
        ServiceNotActive = 0x00000426,

        /// <summary>
        /// An exception occurred in the service when handling the control request.
        /// </summary>
        ExceptionInService = 0x00000428,

        /// <summary>
        /// The database specified does not exist.
        /// </summary>
        DatabaseDoesNotExist = 0x00000429,

        /// <summary>
        /// The service has returned a service-specific error code.
        /// </summary>
        ServiceSpecificError = 0x0000042A,

        /// <summary>
        /// The process terminated unexpectedly.
        /// </summary>
        ProcessAborted = 0x0000042B,

        /// <summary>
        /// The dependency service or group failed to start.
        /// </summary>
        ServiceDependencyFail = 0x0000042C,

        /// <summary>
        /// The service did not start due to a logon failure.
        /// </summary>
        ServiceLogonFailed = 0x0000042D,

        /// <summary>
        /// After starting, the service hung in a start-pending state.
        /// </summary>
        ServiceStartHang = 0x0000042E,

        /// <summary>
        /// The specified service database lock is invalid.
        /// </summary>
        InvalidServiceLock = 0x0000042F,

        /// <summary>
        /// The specified service has been marked for deletion.
        /// </summary>
        ServiceMarkedForDelete = 0x00000430,

        /// <summary>
        /// The specified service already exists.
        /// </summary>
        ServiceExists = 0x00000431,

        /// <summary>
        /// The system is currently running with the last-known-good configuration.
        /// </summary>
        AlreadyRunningLkg = 0x00000432,

        /// <summary>
        /// The current boot has already been accepted for use as the last-known-good control set.
        /// </summary>
        BootAlreadyAccepted = 0x00000434,

        /// <summary>
        /// No attempts to start the service have been made since the last boot.
        /// </summary>
        ServiceNeverStarted = 0x00000435,

        /// <summary>
        /// The name is already in use as either a service name or a service display name.
        /// </summary>
        DuplicateServiceName = 0x00000436,

        /// <summary>
        /// The account specified for this service is different from the account specified for other services running in the same process.
        /// </summary>
        DifferentServiceAccount = 0x00000437,

        /// <summary>
        /// No recovery program has been configured for this service.
        /// </summary>
        NoRecoveryProgram = 0x0000043A,

        /// <summary>
        /// The executable program that this service is configured to run in does not implement the service.
        /// </summary>
        ServiceNotInExe = 0x0000043B,

        /// <summary>
        /// This service cannot be started in Safe Mode
        /// </summary>
        NotSafebootService = 0x0000043C,

        /// <summary>
        /// The physical end of the tape has been reached.
        /// </summary>
        EndOfMedia = 0x0000044C,

        /// <summary>
        /// A tape access reached a filemark.
        /// </summary>
        FilemarkDetected = 0x0000044D,

        /// <summary>
        /// The beginning of the tape or a partition was encountered.
        /// </summary>
        BeginningOfMedia = 0x0000044E,

        /// <summary>
        /// A tape access reached the end of a set of files.
        /// </summary>
        SetmarkDetected = 0x0000044F,

        /// <summary>
        /// No more data is on the tape.
        /// </summary>
        NoDataDetected = 0x00000450,

        /// <summary>
        /// Tape could not be partitioned.
        /// </summary>
        PartitionFailure = 0x00000451,

        /// <summary>
        /// When accessing a new tape of a multivolume partition, the current block size is incorrect.
        /// </summary>
        InvalidBlockLength = 0x00000452,

        /// <summary>
        /// Tape partition information could not be found when loading a tape.
        /// </summary>
        DeviceNotPartitioned = 0x00000453,

        /// <summary>
        /// Unable to lock the media eject mechanism.
        /// </summary>
        UnableToLockMedia = 0x00000454,

        /// <summary>
        /// Unable to unload the media.
        /// </summary>
        UnableToUnloadMedia = 0x00000455,

        /// <summary>
        /// The media in the drive may have changed.
        /// </summary>
        MediaChanged = 0x00000456,

        /// <summary>
        /// The I/O bus was reset.
        /// </summary>
        BusReset = 0x00000457,

        /// <summary>
        /// No media in drive.
        /// </summary>
        NoMediaInDrive = 0x00000458,

        /// <summary>
        /// No mapping for the Unicode character exists in the target multi-byte code page.
        /// </summary>
        NoUnicodeTranslation = 0x00000459,

        /// <summary>
        /// A dynamic link library (DLL) initialization routine failed.
        /// </summary>
        DllInitFailed = 0x0000045A,

        /// <summary>
        /// A system shutdown is in progress.
        /// </summary>
        ShutdownInProgress = 0x0000045B,

        /// <summary>
        /// Unable to abort the system shutdown because no shutdown was in progress.
        /// </summary>
        NoShutdownInProgress = 0x0000045C,

        /// <summary>
        /// The request could not be performed because of an I/O device error.
        /// </summary>
        IoDevice = 0x0000045D,

        /// <summary>
        /// No serial device was successfully initialized. The serial driver will unload.
        /// </summary>
        SerialNoDevice = 0x0000045E,

        /// <summary>
        /// Unable to open a device that was sharing an interrupt request (IRQ) with other devices. At least one other device that uses that IRQ was already opened.
        /// </summary>
        IrqBusy = 0x0000045F,

        /// <summary>
        /// A serial I/O operation was completed by another write to the serial port.
        /// (The IOCTL_SERIAL_XOFF_COUNTER reached zero.)
        /// </summary>
        MoreWrites = 0x00000460,

        /// <summary>
        /// A serial I/O operation completed because the timeout period expired.
        /// (The IOCTL_SERIAL_XOFF_COUNTER did not reach zero.)
        /// </summary>
        CounterTimeout = 0x00000461,

        /// <summary>
        /// No ID address mark was found on the floppy disk.
        /// </summary>
        FloppyIdMarkNotFound = 0x00000462,

        /// <summary>
        /// Mismatch between the floppy disk sector ID field and the floppy disk controller track address.
        /// </summary>
        FloppyWrongCylinder = 0x00000463,

        /// <summary>
        /// The floppy disk controller reported an error that is not recognized by the floppy disk driver.
        /// </summary>
        FloppyUnknownError = 0x00000464,

        /// <summary>
        /// The floppy disk controller returned inconsistent results in its registers.
        /// </summary>
        FloppyBadRegisters = 0x00000465,

        /// <summary>
        /// While accessing the hard disk, a recalibrate operation failed, even after retries.
        /// </summary>
        DiskRecalibrateFailed = 0x00000466,

        /// <summary>
        /// While accessing the hard disk, a disk operation failed even after retries.
        /// </summary>
        DiskOperationFailed = 0x00000467,

        /// <summary>
        /// While accessing the hard disk, a disk controller reset was needed, but even that failed.
        /// </summary>
        DiskResetFailed = 0x00000468,

        /// <summary>
        /// Physical end of tape encountered.
        /// </summary>
        EomOverflow = 0x00000469,

        /// <summary>
        /// Not enough server storage is available to process this command.
        /// </summary>
        NotEnoughServerMemory = 0x0000046A,

        /// <summary>
        /// A potential deadlock condition has been detected.
        /// </summary>
        PossibleDeadlock = 0x0000046B,

        /// <summary>
        /// The base address or the file offset specified does not have the proper alignment.
        /// </summary>
        MappedAlignment = 0x0000046C,

        /// <summary>
        /// An attempt to change the system power state was vetoed by another application or driver.
        /// </summary>
        SetPowerStateVetoed = 0x00000474,

        /// <summary>
        /// The system BIOS failed an attempt to change the system power state.
        /// </summary>
        SetPowerStateFailed = 0x00000475,

        /// <summary>
        /// An attempt was made to create more links on a file than the file system supports.
        /// </summary>
        TooManyLinks = 0x00000476,

        /// <summary>
        /// The specified program requires a newer version of Windows.
        /// </summary>
        OldWinVersion = 0x0000047E,

        /// <summary>
        /// The specified program is not a Windows or MS-DOS program.
        /// </summary>
        AppWrongOs = 0x0000047F,

        /// <summary>
        /// Cannot start more than one instance of the specified program.
        /// </summary>
        SingleInstanceApp = 0x00000480,

        /// <summary>
        /// The specified program was written for an earlier version of Windows.
        /// </summary>
        RmodeApp = 0x00000481,

        /// <summary>
        /// One of the library files needed to run this application is damaged.
        /// </summary>
        InvalidDll = 0x00000482,

        /// <summary>
        /// No application is associated with the specified file for this operation.
        /// </summary>
        NoAssociation = 0x00000483,

        /// <summary>
        /// An error occurred in sending the command to the application.
        /// </summary>
        DdeFail = 0x00000484,

        /// <summary>
        /// One of the library files needed to run this application cannot be found.
        /// </summary>
        DllNotFound = 0x00000485,

        /// <summary>
        /// The current process has used all of its system allowance of handles for Window Manager objects.
        /// </summary>
        NoMoreUserHandles = 0x00000486,

        /// <summary>
        /// The message can be used only with synchronous operations.
        /// </summary>
        MessageSyncOnly = 0x00000487,

        /// <summary>
        /// The indicated source element has no media.
        /// </summary>
        SourceElementEmpty = 0x00000488,

        /// <summary>
        /// The indicated destination element already contains media.
        /// </summary>
        DestinationElementFull = 0x00000489,

        /// <summary>
        /// The indicated element does not exist.
        /// </summary>
        IllegalElementAddress = 0x0000048A,

        /// <summary>
        /// The indicated element is part of a magazine that is not present.
        /// </summary>
        MagazineNotPresent = 0x0000048B,

        /// <summary>
        /// The device has indicated that cleaning is required before further operations are attempted.
        /// </summary>
        DeviceRequiresCleaning = 0x0000048D,

        /// <summary>
        /// The device has indicated that its door is open.
        /// </summary>
        DeviceDoorOpen = 0x0000048E,

        /// <summary>
        /// The device is not connected.
        /// </summary>
        DeviceNotConnected = 0x0000048F,

        /// <summary>
        /// Element not found.
        /// </summary>
        NotFound = 0x00000490,

        /// <summary>
        /// There was no match for the specified key in the index.
        /// </summary>
        NoMatch = 0x00000491,

        /// <summary>
        /// The property set specified does not exist on the object.
        /// </summary>
        SetNotFound = 0x00000492,

        /// <summary>
        /// The point passed to GetMouseMovePoints is not in the buffer.
        /// </summary>
        PointNotFound = 0x00000493,

        /// <summary>
        /// The tracking (workstation) service is not running.
        /// </summary>
        NoTrackingService = 0x00000494,

        /// <summary>
        /// The Volume ID could not be found.
        /// </summary>
        NoVolumeId = 0x00000495,

        /// <summary>
        /// Unable to remove the file to be replaced.
        /// </summary>
        UnableToRemoveReplaced = 0x00000497,

        /// <summary>
        /// The volume change journal is not active.
        /// </summary>
        JournalNotActive = 0x0000049B,

        /// <summary>
        /// A file was found, but it may not be the correct file.
        /// </summary>
        PotentialFileFound = 0x0000049C,

        /// <summary>
        /// The journal entry has been deleted from the journal.
        /// </summary>
        JournalEntryDeleted = 0x0000049D,

        /// <summary>
        /// A system shutdown has already been scheduled.
        /// </summary>
        ShutdownIsScheduled = 0x000004A6,

        /// <summary>
        /// The system shutdown cannot be initiated because there are other users logged on to the computer.
        /// </summary>
        ShutdownUsersLoggedOn = 0x000004A7,

        /// <summary>
        /// The specified device name is invalid.
        /// </summary>
        BadDevice = 0x000004B0,

        /// <summary>
        /// The device is not currently connected but it is a remembered connection.
        /// </summary>
        ConnectionUnavail = 0x000004B1,

        /// <summary>
        /// The local device name has a remembered connection to another network resource.
        /// </summary>
        DeviceAlreadyRemembered = 0x000004B2,

        /// <summary>
        /// The network path was either typed incorrectly, does not exist, or the network provider is not currently available. Please try retyping the path or contact your network administrator.
        /// </summary>
        NoNetOrBadPath = 0x000004B3,

        /// <summary>
        /// The specified network provider name is invalid.
        /// </summary>
        BadProvider = 0x000004B4,

        /// <summary>
        /// Unable to open the network connection profile.
        /// </summary>
        CannotOpenProfile = 0x000004B5,

        /// <summary>
        /// The network connection profile is corrupted.
        /// </summary>
        BadProfile = 0x000004B6,

        /// <summary>
        /// Cannot enumerate a noncontainer.
        /// </summary>
        NotContainer = 0x000004B7,

        /// <summary>
        /// An extended error has occurred.
        /// </summary>
        ExtendedError = 0x000004B8,

        /// <summary>
        /// The format of the specified group name is invalid.
        /// </summary>
        InvalidGroupname = 0x000004B9,

        /// <summary>
        /// The format of the specified computer name is invalid.
        /// </summary>
        InvalidComputername = 0x000004BA,

        /// <summary>
        /// The format of the specified event name is invalid.
        /// </summary>
        InvalidEventname = 0x000004BB,

        /// <summary>
        /// The format of the specified domain name is invalid.
        /// </summary>
        InvalidDomainname = 0x000004BC,

        /// <summary>
        /// The format of the specified service name is invalid.
        /// </summary>
        InvalidServicename = 0x000004BD,

        /// <summary>
        /// The format of the specified network name is invalid.
        /// </summary>
        InvalidNetname = 0x000004BE,

        /// <summary>
        /// The format of the specified share name is invalid.
        /// </summary>
        InvalidSharename = 0x000004BF,

        /// <summary>
        /// The format of the specified password is invalid.
        /// </summary>
        InvalidPasswordname = 0x000004C0,

        /// <summary>
        /// The format of the specified message name is invalid.
        /// </summary>
        InvalidMessagename = 0x000004C1,

        /// <summary>
        /// The format of the specified message destination is invalid.
        /// </summary>
        InvalidMessagedest = 0x000004C2,

        /// <summary>
        /// The workgroup or domain name is already in use by another computer on the network.
        /// </summary>
        DupDomainname = 0x000004C5,

        /// <summary>
        /// The network is not present or not started.
        /// </summary>
        NoNetwork = 0x000004C6,

        /// <summary>
        /// The operation was canceled by the user.
        /// </summary>
        Cancelled = 0x000004C7,

        /// <summary>
        /// The requested operation cannot be performed on a file with a user-mapped section open.
        /// </summary>
        UserMappedFile = 0x000004C8,

        /// <summary>
        /// The remote computer refused the network connection.
        /// </summary>
        ConnectionRefused = 0x000004C9,

        /// <summary>
        /// The network connection was gracefully closed.
        /// </summary>
        GracefulDisconnect = 0x000004CA,

        /// <summary>
        /// An address has not yet been associated with the network endpoint.
        /// </summary>
        AddressNotAssociated = 0x000004CC,

        /// <summary>
        /// An operation was attempted on a nonexistent network connection.
        /// </summary>
        ConnectionInvalid = 0x000004CD,

        /// <summary>
        /// An invalid operation was attempted on an active network connection.
        /// </summary>
        ConnectionActive = 0x000004CE,

        /// <summary>
        /// The network location cannot be reached. For information about network troubleshooting, see Windows Help.
        /// </summary>
        NetworkUnreachable = 0x000004CF,

        /// <summary>
        /// The network location cannot be reached. For information about network troubleshooting, see Windows Help.
        /// </summary>
        HostUnreachable = 0x000004D0,

        /// <summary>
        /// The network location cannot be reached. For information about network troubleshooting, see Windows Help.
        /// </summary>
        ProtocolUnreachable = 0x000004D1,

        /// <summary>
        /// No service is operating at the destination network endpoint on the remote system.
        /// </summary>
        PortUnreachable = 0x000004D2,

        /// <summary>
        /// The request was aborted.
        /// </summary>
        RequestAborted = 0x000004D3,

        /// <summary>
        /// The network connection was aborted by the local system.
        /// </summary>
        ConnectionAborted = 0x000004D4,

        /// <summary>
        /// The operation could not be completed. A retry should be performed.
        /// </summary>
        Retry = 0x000004D5,

        /// <summary>
        /// A connection to the server could not be made because the limit on the number of concurrent connections for this account has been reached.
        /// </summary>
        ConnectionCountLimit = 0x000004D6,

        /// <summary>
        /// Attempting to log in during an unauthorized time of day for this account.
        /// </summary>
        LoginTimeRestriction = 0x000004D7,

        /// <summary>
        /// The account is not authorized to log in from this station.
        /// </summary>
        LoginWkstaRestriction = 0x000004D8,

        /// <summary>
        /// The network address could not be used for the operation requested.
        /// </summary>
        IncorrectAddress = 0x000004D9,

        /// <summary>
        /// The service is already registered.
        /// </summary>
        AlreadyRegistered = 0x000004DA,

        /// <summary>
        /// The specified service does not exist.
        /// </summary>
        ServiceNotFound = 0x000004DB,

        /// <summary>
        /// The operation being requested was not performed because the user has not been authenticated.
        /// </summary>
        NotAuthenticated = 0x000004DC,

        /// <summary>
        /// The operation being requested was not performed because the user has not logged on to the network. The specified service does not exist.
        /// </summary>
        NotLoggedOn = 0x000004DD,

        /// <summary>
        /// Continue with work in progress.
        /// </summary>
        Continue = 0x000004DE,

        /// <summary>
        /// An attempt was made to perform an initialization operation when initialization has already been completed.
        /// </summary>
        AlreadyInitialized = 0x000004DF,

        /// <summary>
        /// No more local devices.
        /// </summary>
        NoMoreDevices = 0x000004E0,

        /// <summary>
        /// The specified site does not exist.
        /// </summary>
        NoSuchSite = 0x000004E1,

        /// <summary>
        /// A domain controller with the specified name already exists.
        /// </summary>
        DomainControllerExists = 0x000004E2,

        /// <summary>
        /// This operation is supported only when you are connected to the server.
        /// </summary>
        OnlyIfConnected = 0x000004E3,

        /// <summary>
        /// The group policy framework should call the extension even if there are no changes.
        /// </summary>
        OverrideNochanges = 0x000004E4,

        /// <summary>
        /// The specified user does not have a valid profile.
        /// </summary>
        BadUserProfile = 0x000004E5,

        /// <summary>
        /// This operation is not supported on a computer running Windows Server 2003 for Small Business Server
        /// </summary>
        NotSupportedOnSbs = 0x000004E6,

        /// <summary>
        /// The remote system is not available. For information about network troubleshooting, see Windows Help.
        /// </summary>
        HostDown = 0x000004E8,

        /// <summary>
        /// The security identifier provided is not from an account domain.
        /// </summary>
        NonAccountSid = 0x000004E9,

        /// <summary>
        /// The security identifier provided does not have a domain component.
        /// </summary>
        NonDomainSid = 0x000004EA,

        /// <summary>
        /// AppHelp dialog canceled thus preventing the application from starting.
        /// </summary>
        ApphelpBlock = 0x000004EB,

        /// <summary>
        /// This program is blocked by group policy. For more information, contact your system administrator.
        /// </summary>
        AccessDisabledByPolicy = 0x000004EC,

        /// <summary>
        /// A program attempt to use an invalid register value. Normally caused by an uninitialized register. This error is Itanium specific.
        /// </summary>
        RegNatConsumption = 0x000004ED,

        /// <summary>
        /// The share is currently offline or does not exist.
        /// </summary>
        CscshareOffline = 0x000004EE,

        /// <summary>
        /// The Kerberos protocol encountered an error while validating the KDC certificate during smartcard logon. There is more information in the system event log.    /// </summary>
        PkinitFailure = 0x000004EF,

        /// <summary>
        /// The system cannot contact a domain controller to service the authentication request. Please try again later.
        /// </summary>
        DowngradeDetected = 0x000004F1,

        /// <summary>
        /// The machine is locked and cannot be shut down without the force option.
        /// </summary>
        MachineLocked = 0x000004F7,

        /// <summary>
        /// This driver has been blocked from loading
        /// </summary>
        DriverBlocked = 0x000004FB,

        /// <summary>
        /// A dynamic link library (DLL) referenced a module that was neither a DLL nor the process's executable image.
        /// </summary>
        InvalidImportOfNonDll = 0x000004FC,

        /// <summary>
        /// Windows cannot open this program since it has been disabled.
        /// </summary>
        AccessDisabledWebblade = 0x000004FD,

        /// <summary>
        /// A transaction recover failed.
        /// </summary>
        RecoveryFailure = 0x000004FF,

        /// <summary>
        /// The current thread has already been converted to a fiber.
        /// </summary>
        AlreadyFiber = 0x00000500,

        /// <summary>
        /// The current thread has already been converted from a fiber.
        /// </summary>
        AlreadyThread = 0x00000501,

        /// <summary>
        /// The system detected an overrun of a stack-based buffer in this application. This overrun could potentially allow a malicious user to gain control of this application.
        /// </summary>
        StackBufferOverrun = 0x00000502,

        /// <summary>
        /// Data present in one of the parameters is more than the function can operate on.
        /// </summary>
        ParameterQuotaExceeded = 0x00000503,

        /// <summary>
        /// An attempt to do an operation on a debug object failed because the object is in the process of being deleted.
        /// </summary>
        DebuggerInactive = 0x00000504,

        /// <summary>
        /// An attempt to delay-load a .dll or get a function address in a delay-loaded .dll failed.
        /// </summary>
        DelayLoadFailed = 0x00000505,

        /// <summary>
        /// %1 is a 16-bit application. You do not have permissions to execute 16-bit applications. Check your permissions with your system administrator.
        /// </summary>
        VdmDisallowed = 0x00000506,

        /// <summary>
        /// Insufficient information exists to identify the cause of failure.
        /// </summary>
        UnidentifiedError = 0x00000507,

        /// <summary>
        /// The operation occurred beyond the valid data length of the file.
        /// </summary>
        BeyondVdl = 0x00000509,

        /// <summary>
        /// The process hosting the driver for this device has been terminated.
        /// </summary>
        DriverProcessTerminated = 0x0000050B,

        /// <summary>
        /// An operation attempted to exceed an implementation-defined limit.
        /// </summary>
        ImplementationLimit = 0x0000050C,

        /// <summary>
        /// Either the target process, or the target thread's containing process, is a protected process.
        /// </summary>
        ProcessIsProtected = 0x0000050D,

        /// <summary>
        /// The requested file operation failed because the storage quota was exceeded.
        /// To free up disk space, move files to a different location or delete unnecessary files. For more information, contact your system administrator.
        /// </summary>
        DiskQuotaExceeded = 0x0000050F,

        /// <summary>
        /// The requested file operation failed because the storage policy blocks that type of file. For more information, contact your system administrator.
        /// </summary>
        ContentBlocked = 0x00000510,

        /// <summary>
        /// A thread involved in this operation appears to be unresponsive.
        /// </summary>
        AppHang = 0x00000512,

        /// <summary>
        /// Indicates a particular Security ID may not be assigned as the label of an object.
        /// </summary>
        InvalidLabel = 0x00000513,

        /// <summary>
        /// Not all privileges or groups referenced are assigned to the caller.
        /// </summary>
        NotAllAssigned = 0x00000514,

        /// <summary>
        /// Some mapping between account names and security IDs was not done.
        /// </summary>
        SomeNotMapped = 0x00000515,

        /// <summary>
        /// No system quota limits are specifically set for this account.
        /// </summary>
        NoQuotasForAccount = 0x00000516,

        /// <summary>
        /// No encryption key is available. A well-known encryption key was returned.
        /// </summary>
        LocalUserSessionKey = 0x00000517,

        /// <summary>
        /// The password is too complex to be converted to a LAN Manager password. The LAN Manager password returned is a NULL string.
        /// </summary>
        NullLmPassword = 0x00000518,

        /// <summary>
        /// The revision level is unknown.
        /// </summary>
        UnknownRevision = 0x00000519,

        /// <summary>
        /// Indicates two revision levels are incompatible.
        /// </summary>
        RevisionMismatch = 0x0000051A,

        /// <summary>
        /// This security ID may not be assigned as the owner of this object.
        /// </summary>
        InvalidOwner = 0x0000051B,

        /// <summary>
        /// This security ID may not be assigned as the primary group of an object.
        /// </summary>
        InvalidPrimaryGroup = 0x0000051C,

        /// <summary>
        /// An attempt has been made to operate on an impersonation token by a thread that is not currently impersonating a client.
        /// </summary>
        NoImpersonationToken = 0x0000051D,

        /// <summary>
        /// The group may not be disabled.
        /// </summary>
        CantDisableMandatory = 0x0000051E,

        /// <summary>
        /// There are currently no logon servers available to service the logon request.
        /// </summary>
        NoLogonServers = 0x0000051F,

        /// <summary>
        /// A specified logon session does not exist. It may already have been terminated.
        /// </summary>
        NoSuchLogonSession = 0x00000520,

        /// <summary>
        /// A specified privilege does not exist.
        /// </summary>
        NoSuchPrivilege = 0x00000521,

        /// <summary>
        /// A required privilege is not held by the client.
        /// </summary>
        PrivilegeNotHeld = 0x00000522,

        /// <summary>
        /// The name provided is not a properly formed account name.
        /// </summary>
        InvalidAccountName = 0x00000523,

        /// <summary>
        /// The specified account already exists.
        /// </summary>
        UserExists = 0x00000524,

        /// <summary>
        /// The specified account does not exist.
        /// </summary>
        NoSuchUser = 0x00000525,

        /// <summary>
        /// The specified group already exists.
        /// </summary>
        GroupExists = 0x00000526,

        /// <summary>
        /// The specified group does not exist.
        /// </summary>
        NoSuchGroup = 0x00000527,

        /// <summary>
        /// Either the specified user account is already a member of the specified group, or the specified group cannot be deleted because it contains a member.
        /// </summary>
        MemberInGroup = 0x00000528,

        /// <summary>
        /// The specified user account is not a member of the specified group account.
        /// </summary>
        MemberNotInGroup = 0x00000529,

        /// <summary>
        /// This operation is disallowed as it could result in an administration account being disabled, deleted or unable to logon.
        /// </summary>
        LastAdmin = 0x0000052A,

        /// <summary>
        /// Unable to update the password. The value provided as the current password is incorrect.
        /// </summary>
        WrongPassword = 0x0000052B,

        /// <summary>
        /// Unable to update the password. The value provided for the new password contains values that are not allowed in passwords.
        /// </summary>
        IllFormedPassword = 0x0000052C,

        /// <summary>
        /// Unable to update the password. The value provided for the new password does not meet the length, complexity, or history requirements of the domain.
        /// </summary>
        PasswordRestriction = 0x0000052D,

        /// <summary>
        /// The user name or password is incorrect.
        /// </summary>
        LogonFailure = 0x0000052E,

        /// <summary>
        /// Account restrictions are preventing this user from signing in. For example: blank passwords aren't allowed, sign-in times are limited, or a policy restriction has been enforced.
        /// </summary>
        AccountRestriction = 0x0000052F,

        /// <summary>
        /// Your account has time restrictions that keep you from signing in right now.
        /// </summary>
        InvalidLogonHours = 0x00000530,

        /// <summary>
        /// This user isn't allowed to sign in to this computer.
        /// </summary>
        InvalidWorkstation = 0x00000531,

        /// <summary>
        /// The password for this account has expired.
        /// </summary>
        PasswordExpired = 0x00000532,

        /// <summary>
        /// This user can't sign in because this account is currently disabled.
        /// </summary>
        AccountDisabled = 0x00000533,

        /// <summary>
        /// No mapping between account names and security IDs was done.
        /// </summary>
        NoneMapped = 0x00000534,

        /// <summary>
        /// Too many local user identifiers (LUIDs) were requested at one time.
        /// </summary>
        TooManyLuidsRequested = 0x00000535,

        /// <summary>
        /// No more local user identifiers (LUIDs) are available.
        /// </summary>
        LuidsExhausted = 0x00000536,

        /// <summary>
        /// The subauthority part of a security ID is invalid for this particular use.
        /// </summary>
        InvalidSubAuthority = 0x00000537,

        /// <summary>
        /// The access control list (ACL) structure is invalid.
        /// </summary>
        InvalidAcl = 0x00000538,

        /// <summary>
        /// The security ID structure is invalid.
        /// </summary>
        InvalidSid = 0x00000539,

        /// <summary>
        /// The security descriptor structure is invalid.
        /// </summary>
        InvalidSecurityDescr = 0x0000053A,

        /// <summary>
        /// The inherited access control list (ACL) or access control entry (ACE) could not be built.
        /// </summary>
        BadInheritanceAcl = 0x0000053C,

        /// <summary>
        /// The server is currently disabled.
        /// </summary>
        ServerDisabled = 0x0000053D,

        /// <summary>
        /// The server is currently enabled.
        /// </summary>
        ServerNotDisabled = 0x0000053E,

        /// <summary>
        /// The value provided was an invalid value for an identifier authority.
        /// </summary>
        InvalidIdAuthority = 0x0000053F,

        /// <summary>
        /// No more memory is available for security information updates.
        /// </summary>
        AllottedSpaceExceeded = 0x00000540,

        /// <summary>
        /// The specified attributes are invalid, or incompatible with the attributes for the group as a whole.
        /// </summary>
        InvalidGroupAttributes = 0x00000541,

        /// <summary>
        /// Either a required impersonation level was not provided, or the provided impersonation level is invalid.
        /// </summary>
        BadImpersonationLevel = 0x00000542,

        /// <summary>
        /// Cannot open an anonymous level security token.
        /// </summary>
        CantOpenAnonymous = 0x00000543,

        /// <summary>
        /// The validation information class requested was invalid.
        /// </summary>
        BadValidationClass = 0x00000544,

        /// <summary>
        /// The type of the token is inappropriate for its attempted use.
        /// </summary>
        BadTokenType = 0x00000545,

        /// <summary>
        /// Unable to perform a security operation on an object that has no associated security.
        /// </summary>
        NoSecurityOnObject = 0x00000546,

        /// <summary>
        /// Configuration information could not be read from the domain controller, either because the machine is unavailable, or access has been denied.
        /// </summary>
        CantAccessDomainInfo = 0x00000547,

        /// <summary>
        /// The security account manager (SAM) or local security authority (LSA) server was in the wrong state to perform the security operation.
        /// </summary>
        InvalidServerState = 0x00000548,

        /// <summary>
        /// The domain was in the wrong state to perform the security operation.
        /// </summary>
        InvalidDomainState = 0x00000549,

        /// <summary>
        /// This operation is only allowed for the Primary Domain Controller of the domain.
        /// </summary>
        InvalidDomainRole = 0x0000054A,

        /// <summary>
        /// The specified domain either does not exist or could not be contacted.
        /// </summary>
        NoSuchDomain = 0x0000054B,

        /// <summary>
        /// The specified domain already exists.
        /// </summary>
        DomainExists = 0x0000054C,

        /// <summary>
        /// An attempt was made to exceed the limit on the number of domains per server.
        /// </summary>
        DomainLimitExceeded = 0x0000054D,

        /// <summary>
        /// Unable to complete the requested operation because of either a catastrophic media failure or a data structure corruption on the disk.
        /// </summary>
        InternalDbCorruption = 0x0000054E,

        /// <summary>
        /// An internal error occurred.
        /// </summary>
        InternalError = 0x0000054F,

        /// <summary>
        /// Generic access types were contained in an access mask which should already be mapped to nongeneric types.
        /// </summary>
        GenericNotMapped = 0x00000550,

        /// <summary>
        /// A security descriptor is not in the right format (absolute or self-relative).
        /// </summary>
        BadDescriptorFormat = 0x00000551,

        /// <summary>
        /// The requested action is restricted for use by logon processes only. The calling process has not registered as a logon process.
        /// </summary>
        NotLogonProcess = 0x00000552,

        /// <summary>
        /// Cannot start a new logon session with an ID that is already in use.
        /// </summary>
        LogonSessionExists = 0x00000553,

        /// <summary>
        /// A specified authentication package is unknown.
        /// </summary>
        NoSuchPackage = 0x00000554,

        /// <summary>
        /// The logon session is not in a state that is consistent with the requested operation.
        /// </summary>
        BadLogonSessionState = 0x00000555,

        /// <summary>
        /// The logon session ID is already in use.
        /// </summary>
        LogonSessionCollision = 0x00000556,

        /// <summary>
        /// A logon request contained an invalid logon type value.
        /// </summary>
        InvalidLogonType = 0x00000557,

        /// <summary>
        /// Unable to impersonate using a named pipe until data has been read from that pipe.
        /// </summary>
        CannotImpersonate = 0x00000558,

        /// <summary>
        /// The transaction state of a registry subtree is incompatible with the requested operation.
        /// </summary>
        RxactInvalidState = 0x00000559,

        /// <summary>
        /// An internal security database corruption has been encountered.
        /// </summary>
        RxactCommitFailure = 0x0000055A,

        /// <summary>
        /// Cannot perform this operation on built-in accounts.
        /// </summary>
        SpecialAccount = 0x0000055B,

        /// <summary>
        /// Cannot perform this operation on this built-in special group.
        /// </summary>
        SpecialGroup = 0x0000055C,

        /// <summary>
        /// Cannot perform this operation on this built-in special user.
        /// </summary>
        SpecialUser = 0x0000055D,

        /// <summary>
        /// The user cannot be removed from a group because the group is currently the user's primary group.
        /// </summary>
        MembersPrimaryGroup = 0x0000055E,

        /// <summary>
        /// The token is already in use as a primary token.
        /// </summary>
        TokenAlreadyInUse = 0x0000055F,

        /// <summary>
        /// The specified local group does not exist.
        /// </summary>
        NoSuchAlias = 0x00000560,

        /// <summary>
        /// The specified account name is not a member of the group.
        /// </summary>
        MemberNotInAlias = 0x00000561,

        /// <summary>
        /// The specified account name is already a member of the group.
        /// </summary>
        MemberInAlias = 0x00000562,

        /// <summary>
        /// The specified local group already exists.
        /// </summary>
        AliasExists = 0x00000563,

        /// <summary>
        /// Logon failure: the user has not been granted the requested logon type at this computer.
        /// </summary>
        LogonNotGranted = 0x00000564,

        /// <summary>
        /// The maximum number of secrets that may be stored in a single system has been exceeded.
        /// </summary>
        TooManySecrets = 0x00000565,

        /// <summary>
        /// The length of a secret exceeds the maximum length allowed.
        /// </summary>
        SecretTooLong = 0x00000566,

        /// <summary>
        /// The local security authority database contains an internal inconsistency.
        /// </summary>
        InternalDbError = 0x00000567,

        /// <summary>
        /// During a logon attempt, the user's security context accumulated too many security IDs.
        /// </summary>
        TooManyContextIds = 0x00000568,

        /// <summary>
        /// Logon failure: the user has not been granted the requested logon type at this computer.
        /// </summary>
        LogonTypeNotGranted = 0x00000569,

        /// <summary>
        /// A member could not be added to or removed from the local group because the member does not exist.
        /// </summary>
        NoSuchMember = 0x0000056B,

        /// <summary>
        /// A new member could not be added to a local group because the member has the wrong account type.
        /// </summary>
        InvalidMember = 0x0000056C,

        /// <summary>
        /// Too many security IDs have been specified.
        /// </summary>
        TooManySids = 0x0000056D,

        /// <summary>
        /// Indicates an ACL contains no inheritable components.
        /// </summary>
        NoInheritance = 0x0000056F,

        /// <summary>
        /// The file or directory is corrupted and unreadable.
        /// </summary>
        FileCorrupt = 0x00000570,

        /// <summary>
        /// The disk structure is corrupted and unreadable.
        /// </summary>
        DiskCorrupt = 0x00000571,

        /// <summary>
        /// There is no user session key for the specified logon session.
        /// </summary>
        NoUserSessionKey = 0x00000572,

        /// <summary>
        /// The service being accessed is licensed for a particular number of connections. No more connections can be made to the service at this time because there are already as many connections as the service can accept.
        /// </summary>
        LicenseQuotaExceeded = 0x00000573,

        /// <summary>
        /// The target account name is incorrect.
        /// </summary>
        WrongTargetName = 0x00000574,

        /// <summary>
        /// Mutual Authentication failed. The server's password is out of date at the domain controller.
        /// </summary>
        MutualAuthFailed = 0x00000575,

        /// <summary>
        /// There is a time and/or date difference between the client and server.
        /// </summary>
        TimeSkew = 0x00000576,

        /// <summary>
        /// Invalid window handle.
        /// </summary>
        InvalidWindowHandle = 0x00000578,

        /// <summary>
        /// Invalid menu handle.
        /// </summary>
        InvalidMenuHandle = 0x00000579,

        /// <summary>
        /// Invalid cursor handle.
        /// </summary>
        InvalidCursorHandle = 0x0000057A,

        /// <summary>
        /// Invalid accelerator table handle.
        /// </summary>
        InvalidAccelHandle = 0x0000057B,

        /// <summary>
        /// Invalid hook handle.
        /// </summary>
        InvalidHookHandle = 0x0000057C,

        /// <summary>
        /// Invalid handle to a multiple-window position structure.
        /// </summary>
        InvalidDwpHandle = 0x0000057D,

        /// <summary>
        /// Cannot create a top-level child window.
        /// </summary>
        TlwWithWschild = 0x0000057E,

        /// <summary>
        /// Cannot find window class.
        /// </summary>
        CannotFindWndClass = 0x0000057F,

        /// <summary>
        /// Invalid window; it belongs to other thread.
        /// </summary>
        WindowOfOtherThread = 0x00000580,

        /// <summary>
        /// Hot key is already registered.
        /// </summary>
        HotkeyAlreadyRegistered = 0x00000581,

        /// <summary>
        /// Class already exists.
        /// </summary>
        ClassAlreadyExists = 0x00000582,

        /// <summary>
        /// Class does not exist.
        /// </summary>
        ClassDoesNotExist = 0x00000583,

        /// <summary>
        /// Class still has open windows.
        /// </summary>
        ClassHasWindows = 0x00000584,

        /// <summary>
        /// Invalid index.
        /// </summary>
        InvalidIndex = 0x00000585,

        /// <summary>
        /// Invalid icon handle.
        /// </summary>
        InvalidIconHandle = 0x00000586,

        /// <summary>
        /// Using private DIALOG window words.
        /// </summary>
        PrivateDialogIndex = 0x00000587,

        /// <summary>
        /// The list box identifier was not found.
        /// </summary>
        ListboxIdNotFound = 0x00000588,

        /// <summary>
        /// No wildcards were found.
        /// </summary>
        NoWildcardCharacters = 0x00000589,

        /// <summary>
        /// Thread does not have a clipboard open.
        /// </summary>
        ClipboardNotOpen = 0x0000058A,

        /// <summary>
        /// Hot key is not registered.
        /// </summary>
        HotkeyNotRegistered = 0x0000058B,

        /// <summary>
        /// The window is not a valid dialog window.
        /// </summary>
        WindowNotDialog = 0x0000058C,

        /// <summary>
        /// Control ID not found.
        /// </summary>
        ControlIdNotFound = 0x0000058D,

        /// <summary>
        /// Invalid message for a combo box because it does not have an edit control.
        /// </summary>
        InvalidComboboxMessage = 0x0000058E,

        /// <summary>
        /// The window is not a combo box.
        /// </summary>
        WindowNotCombobox = 0x0000058F,

        /// <summary>
        /// Height must be less than 256.
        /// </summary>
        InvalidEditHeight = 0x00000590,

        /// <summary>
        /// Invalid device context (DC) handle.
        /// </summary>
        DcNotFound = 0x00000591,

        /// <summary>
        /// Invalid hook procedure type.
        /// </summary>
        InvalidHookFilter = 0x00000592,

        /// <summary>
        /// Invalid hook procedure.
        /// </summary>
        InvalidFilterProc = 0x00000593,

        /// <summary>
        /// Cannot set nonlocal hook without a module handle.
        /// </summary>
        HookNeedsHmod = 0x00000594,

        /// <summary>
        /// This hook procedure can only be set globally.
        /// </summary>
        GlobalOnlyHook = 0x00000595,

        /// <summary>
        /// The journal hook procedure is already installed.
        /// </summary>
        JournalHookSet = 0x00000596,

        /// <summary>
        /// The hook procedure is not installed.
        /// </summary>
        HookNotInstalled = 0x00000597,

        /// <summary>
        /// Invalid message for single-selection list box.
        /// </summary>
        InvalidLbMessage = 0x00000598,

        /// <summary>
        /// LB_SETCOUNT sent to non-lazy list box.
        /// </summary>
        SetcountOnBadLb = 0x00000599,

        /// <summary>
        /// This list box does not support tab stops.
        /// </summary>
        LbWithoutTabstops = 0x0000059A,

        /// <summary>
        /// Child windows cannot have menus.
        /// </summary>
        ChildWindowMenu = 0x0000059C,

        /// <summary>
        /// The window does not have a system menu.
        /// </summary>
        NoSystemMenu = 0x0000059D,

        /// <summary>
        /// Invalid message box style.
        /// </summary>
        InvalidMsgboxStyle = 0x0000059E,

        /// <summary>
        /// Invalid system-wide (SPI_*) parameter.
        /// </summary>
        InvalidSpiValue = 0x0000059F,

        /// <summary>
        /// Screen already locked.
        /// </summary>
        ScreenAlreadyLocked = 0x000005A0,

        /// <summary>
        /// All handles to windows in a multiple-window position structure must have the same parent.
        /// </summary>
        HwndsHaveDiffParent = 0x000005A1,

        /// <summary>
        /// The window is not a child window.
        /// </summary>
        NotChildWindow = 0x000005A2,

        /// <summary>
        /// Invalid GW_* command.
        /// </summary>
        InvalidGwCommand = 0x000005A3,

        /// <summary>
        /// Invalid thread identifier.
        /// </summary>
        InvalidThreadId = 0x000005A4,

        /// <summary>
        /// Cannot process a message from a window that is not a multiple document interface (MDI) window.
        /// </summary>
        NonMdichildWindow = 0x000005A5,

        /// <summary>
        /// Popup menu already active.
        /// </summary>
        PopupAlreadyActive = 0x000005A6,

        /// <summary>
        /// The window does not have scroll bars.
        /// </summary>
        NoScrollbars = 0x000005A7,

        /// <summary>
        /// Scroll bar range cannot be greater than MAXLONG.
        /// </summary>
        InvalidScrollbarRange = 0x000005A8,

        /// <summary>
        /// Cannot show or remove the window in the way specified.
        /// </summary>
        InvalidShowwinCommand = 0x000005A9,

        /// <summary>
        /// Insufficient system resources exist to complete the requested service.
        /// </summary>
        NoSystemResources = 0x000005AA,

        /// <summary>
        /// Insufficient system resources exist to complete the requested service.
        /// </summary>
        NonpagedSystemResources = 0x000005AB,

        /// <summary>
        /// Insufficient system resources exist to complete the requested service.
        /// </summary>
        PagedSystemResources = 0x000005AC,

        /// <summary>
        /// Insufficient quota to complete the requested service.
        /// </summary>
        WorkingSetQuota = 0x000005AD,

        /// <summary>
        /// Insufficient quota to complete the requested service.
        /// </summary>
        PagefileQuota = 0x000005AE,

        /// <summary>
        /// The paging file is too small for this operation to complete.
        /// </summary>
        CommitmentLimit = 0x000005AF,

        /// <summary>
        /// A menu item was not found.
        /// </summary>
        MenuItemNotFound = 0x000005B0,

        /// <summary>
        /// Invalid keyboard layout handle.
        /// </summary>
        InvalidKeyboardHandle = 0x000005B1,

        /// <summary>
        /// Hook type not allowed.
        /// </summary>
        HookTypeNotAllowed = 0x000005B2,

        /// <summary>
        /// This operation returned because the timeout period expired.
        /// </summary>
        Timeout = 0x000005B4,

        /// <summary>
        /// Invalid monitor handle.
        /// </summary>
        InvalidMonitorHandle = 0x000005B5,

        /// <summary>
        /// Incorrect size argument.
        /// </summary>
        IncorrectSize = 0x000005B6,

        /// <summary>
        /// The symbolic link cannot be followed because its type is disabled.
        /// </summary>
        SymlinkClassDisabled = 0x000005B7,

        /// <summary>
        /// This application does not support the current operation on symbolic links.
        /// </summary>
        SymlinkNotSupported = 0x000005B8,

        /// <summary>
        /// Windows was unable to parse the requested XML data.
        /// </summary>
        XmlParseError = 0x000005B9,

        /// <summary>
        /// An error was encountered while processing an XML digital signature.
        /// </summary>
        XmldsigError = 0x000005BA,

        /// <summary>
        /// This application must be restarted.
        /// </summary>
        RestartApplication = 0x000005BB,

        /// <summary>
        /// The caller made the connection request in the wrong routing compartment.
        /// </summary>
        WrongCompartment = 0x000005BC,

        /// <summary>
        /// There was an AuthIP failure when attempting to connect to the remote host.
        /// </summary>
        AuthipFailure = 0x000005BD,

        /// <summary>
        /// Insufficient NVRAM resources exist to complete the requested service. A reboot might be required.
        /// </summary>
        NoNvramResources = 0x000005BE,

        /// <summary>
        /// Unable to finish the requested operation because the specified process is not a GUI process.
        /// </summary>
        NotGuiProcess = 0x000005BF,

        /// <summary>
        /// The event log file is corrupted.
        /// </summary>
        EventlogFileCorrupt = 0x000005DC,

        /// <summary>
        /// No event log file could be opened, so the event logging service did not start.
        /// </summary>
        EventlogCantStart = 0x000005DD,

        /// <summary>
        /// The event log file is full.
        /// </summary>
        LogFileFull = 0x000005DE,

        /// <summary>
        /// The event log file has changed between read operations.
        /// </summary>
        EventlogFileChanged = 0x000005DF,

        /// <summary>
        /// The specified task name is invalid.
        /// </summary>
        InvalidTaskName = 0x0000060E,

        /// <summary>
        /// The specified task index is invalid.
        /// </summary>
        InvalidTaskIndex = 0x0000060F,

        /// <summary>
        /// The specified thread is already joining a task.
        /// </summary>
        ThreadAlreadyInTask = 0x00000610,

        /// <summary>
        /// The Windows Installer Service could not be accessed. This can occur if the Windows Installer is not correctly installed. Contact your support personnel for assistance.
        /// </summary>
        InstallServiceFailure = 0x00000641,

        /// <summary>
        /// User cancelled installation.
        /// </summary>
        InstallUserexit = 0x00000642,

        /// <summary>
        /// Fatal error during installation.
        /// </summary>
        InstallFailure = 0x00000643,

        /// <summary>
        /// Installation suspended, incomplete.
        /// </summary>
        InstallSuspend = 0x00000644,

        /// <summary>
        /// This action is only valid for products that are currently installed.
        /// </summary>
        UnknownProduct = 0x00000645,

        /// <summary>
        /// Feature ID not registered.
        /// </summary>
        UnknownFeature = 0x00000646,

        /// <summary>
        /// Component ID not registered.
        /// </summary>
        UnknownComponent = 0x00000647,

        /// <summary>
        /// Unknown property.
        /// </summary>
        UnknownProperty = 0x00000648,

        /// <summary>
        /// Handle is in an invalid state.
        /// </summary>
        InvalidHandleState = 0x00000649,

        /// <summary>
        /// The configuration data for this product is corrupt. Contact your support personnel.
        /// </summary>
        BadConfiguration = 0x0000064A,

        /// <summary>
        /// Component qualifier not present.
        /// </summary>
        IndexAbsent = 0x0000064B,

        /// <summary>
        /// The installation source for this product is not available. Verify that the source exists and that you can access it.
        /// </summary>
        InstallSourceAbsent = 0x0000064C,

        /// <summary>
        /// This installation package cannot be installed by the Windows Installer service. You must install a Windows service pack that contains a newer version of the Windows Installer service.
        /// </summary>
        InstallPackageVersion = 0x0000064D,

        /// <summary>
        /// Product is uninstalled.
        /// </summary>
        ProductUninstalled = 0x0000064E,

        /// <summary>
        /// SQL query syntax invalid or unsupported.
        /// </summary>
        BadQuerySyntax = 0x0000064F,

        /// <summary>
        /// Record field does not exist.
        /// </summary>
        InvalidField = 0x00000650,

        /// <summary>
        /// The device has been removed.
        /// </summary>
        DeviceRemoved = 0x00000651,

        /// <summary>
        /// Another installation is already in progress. Complete that installation before proceeding with this install.
        /// </summary>
        InstallAlreadyRunning = 0x00000652,

        /// <summary>
        /// This installation package could not be opened. Contact the application vendor to verify that this is a valid Windows Installer package.
        /// </summary>
        InstallPackageInvalid = 0x00000654,

        /// <summary>
        /// There was an error starting the Windows Installer service user interface. Contact your support personnel.
        /// </summary>
        InstallUiFailure = 0x00000655,

        /// <summary>
        /// Error opening installation log file. Verify that the specified log file location exists and that you can write to it.
        /// </summary>
        InstallLogFailure = 0x00000656,

        /// <summary>
        /// Error applying transforms. Verify that the specified transform paths are valid.
        /// </summary>
        InstallTransformFailure = 0x00000658,

        /// <summary>
        /// This installation is forbidden by system policy. Contact your system administrator.
        /// </summary>
        InstallPackageRejected = 0x00000659,

        /// <summary>
        /// Function could not be executed.
        /// </summary>
        FunctionNotCalled = 0x0000065A,

        /// <summary>
        /// Function failed during execution.
        /// </summary>
        FunctionFailed = 0x0000065B,

        /// <summary>
        /// Invalid or unknown table specified.
        /// </summary>
        InvalidTable = 0x0000065C,

        /// <summary>
        /// Data supplied is of wrong type.
        /// </summary>
        DatatypeMismatch = 0x0000065D,

        /// <summary>
        /// Data of this type is not supported.
        /// </summary>
        UnsupportedType = 0x0000065E,

        /// <summary>
        /// The Windows Installer service failed to start. Contact your support personnel.
        /// </summary>
        CreateFailed = 0x0000065F,

        /// <summary>
        /// The Temp folder is on a drive that is full or is inaccessible. Free up space on the drive or verify that you have write permission on the Temp folder.
        /// </summary>
        InstallTempUnwritable = 0x00000660,

        /// <summary>
        /// Component not used on this computer.
        /// </summary>
        InstallNotused = 0x00000662,

        /// <summary>
        /// This update package could not be opened. Verify that the update package exists and that you can access it, or contact the application vendor to verify that this is a valid Windows Installer update package.
        /// </summary>
        PatchPackageOpenFailed = 0x00000663,

        /// <summary>
        /// This update package could not be opened. Contact the application vendor to verify that this is a valid Windows Installer update package.
        /// </summary>
        PatchPackageInvalid = 0x00000664,

        /// <summary>
        /// This update package cannot be processed by the Windows Installer service. You must install a Windows service pack that contains a newer version of the Windows Installer service.
        /// </summary>
        PatchPackageUnsupported = 0x00000665,

        /// <summary>
        /// Another version of this product is already installed. Installation of this version cannot continue. To configure or remove the existing version of this product, use Add/Remove Programs on the Control Panel.
        /// </summary>
        ProductVersion = 0x00000666,

        /// <summary>
        /// Invalid command line argument. Consult the Windows Installer SDK for detailed command line help.
        /// </summary>
        InvalidCommandLine = 0x00000667,

        /// <summary>
        /// Only administrators have permission to add, remove, or configure server software during a Terminal services remote session. If you want to install or configure software on the server, contact your network administrator.
        /// </summary>
        InstallRemoteDisallowed = 0x00000668,

        /// <summary>
        /// The requested operation completed successfully. The system will be restarted so the changes can take effect.
        /// </summary>
        SuccessRebootInitiated = 0x00000669,

        /// <summary>
        /// The upgrade cannot be installed by the Windows Installer service because the program to be upgraded may be missing, or the upgrade may update a different version of the program. Verify that the program to be upgraded exists on your computer and that you have the correct upgrade.
        /// </summary>
        PatchTargetNotFound = 0x0000066A,

        /// <summary>
        /// The update package is not permitted by software restriction policy.
        /// </summary>
        PatchPackageRejected = 0x0000066B,

        /// <summary>
        /// The Windows Installer does not permit installation from a Remote Desktop Connection.
        /// </summary>
        InstallRemoteProhibited = 0x0000066D,

        /// <summary>
        /// Uninstallation of the update package is not supported.
        /// </summary>
        PatchRemovalUnsupported = 0x0000066E,

        /// <summary>
        /// The update is not applied to this product.
        /// </summary>
        UnknownPatch = 0x0000066F,

        /// <summary>
        /// No valid sequence could be found for the set of updates.
        /// </summary>
        PatchNoSequence = 0x00000670,

        /// <summary>
        /// Update removal was disallowed by policy.
        /// </summary>
        PatchRemovalDisallowed = 0x00000671,

        /// <summary>
        /// The XML update data is invalid.
        /// </summary>
        InvalidPatchXml = 0x00000672,

        /// <summary>
        /// The Windows Installer service is not accessible in Safe Mode. Please try again when your computer is not in Safe Mode or you can use System Restore to return your machine to a previous good state.
        /// </summary>
        InstallServiceSafeboot = 0x00000674,

        /// <summary>
        /// A fail fast exception occurred. Exception handlers will not be invoked and the process will be terminated immediately.
        /// </summary>
        FailFastException = 0x00000675,

        /// <summary>
        /// The app that you are trying to run is not supported on this version of Windows.
        /// </summary>
        InstallRejected = 0x00000676,

        /// <summary>
        /// The operation was blocked as the process prohibits dynamic code generation.
        /// </summary>
        DynamicCodeBlocked = 0x00000677,

        /// <summary>
        /// The string binding is invalid.
        /// </summary>
        RpcSInvalidStringBinding = 0x000006A4,

        /// <summary>
        /// The binding handle is not the correct type.
        /// </summary>
        RpcSWrongKindOfBinding = 0x000006A5,

        /// <summary>
        /// The binding handle is invalid.
        /// </summary>
        RpcSInvalidBinding = 0x000006A6,

        /// <summary>
        /// The RPC protocol sequence is not supported.
        /// </summary>
        RpcSProtseqNotSupported = 0x000006A7,

        /// <summary>
        /// The RPC protocol sequence is invalid.
        /// </summary>
        RpcSInvalidRpcProtseq = 0x000006A8,

        /// <summary>
        /// The string universal unique identifier (UUID) is invalid.
        /// </summary>
        RpcSInvalidStringUuid = 0x000006A9,

        /// <summary>
        /// The endpoint format is invalid.
        /// </summary>
        RpcSInvalidEndpointFormat = 0x000006AA,

        /// <summary>
        /// The network address is invalid.
        /// </summary>
        RpcSInvalidNetAddr = 0x000006AB,

        /// <summary>
        /// No endpoint was found.
        /// </summary>
        RpcSNoEndpointFound = 0x000006AC,

        /// <summary>
        /// The timeout value is invalid.
        /// </summary>
        RpcSInvalidTimeout = 0x000006AD,

        /// <summary>
        /// The object universal unique identifier (UUID) was not found.
        /// </summary>
        RpcSObjectNotFound = 0x000006AE,

        /// <summary>
        /// The object universal unique identifier (UUID) has already been registered.
        /// </summary>
        RpcSAlreadyRegistered = 0x000006AF,

        /// <summary>
        /// The type universal unique identifier (UUID) has already been registered.
        /// </summary>
        RpcSTypeAlreadyRegistered = 0x000006B0,

        /// <summary>
        /// The RPC server is already listening.
        /// </summary>
        RpcSAlreadyListening = 0x000006B1,

        /// <summary>
        /// No protocol sequences have been registered.
        /// </summary>
        RpcSNoProtseqsRegistered = 0x000006B2,

        /// <summary>
        /// The RPC server is not listening.
        /// </summary>
        RpcSNotListening = 0x000006B3,

        /// <summary>
        /// The manager type is unknown.
        /// </summary>
        RpcSUnknownMgrType = 0x000006B4,

        /// <summary>
        /// The interface is unknown.
        /// </summary>
        RpcSUnknownIf = 0x000006B5,

        /// <summary>
        /// There are no bindings.
        /// </summary>
        RpcSNoBindings = 0x000006B6,

        /// <summary>
        /// There are no protocol sequences.
        /// </summary>
        RpcSNoProtseqs = 0x000006B7,

        /// <summary>
        /// The endpoint cannot be created.
        /// </summary>
        RpcSCantCreateEndpoint = 0x000006B8,

        /// <summary>
        /// Not enough resources are available to complete this operation.
        /// </summary>
        RpcSOutOfResources = 0x000006B9,

        /// <summary>
        /// The RPC server is unavailable.
        /// </summary>
        RpcSServerUnavailable = 0x000006BA,

        /// <summary>
        /// The RPC server is too busy to complete this operation.
        /// </summary>
        RpcSServerTooBusy = 0x000006BB,

        /// <summary>
        /// The network options are invalid.
        /// </summary>
        RpcSInvalidNetworkOptions = 0x000006BC,

        /// <summary>
        /// There are no remote procedure calls active on this thread.
        /// </summary>
        RpcSNoCallActive = 0x000006BD,

        /// <summary>
        /// The remote procedure call failed.
        /// </summary>
        RpcSCallFailed = 0x000006BE,

        /// <summary>
        /// The remote procedure call failed and did not execute.
        /// </summary>
        RpcSCallFailedDne = 0x000006BF,

        /// <summary>
        /// A remote procedure call (RPC) protocol error occurred.
        /// </summary>
        RpcSProtocolError = 0x000006C0,

        /// <summary>
        /// Access to the HTTP proxy is denied.
        /// </summary>
        RpcSProxyAccessDenied = 0x000006C1,

        /// <summary>
        /// The transfer syntax is not supported by the RPC server.
        /// </summary>
        RpcSUnsupportedTransSyn = 0x000006C2,

        /// <summary>
        /// The universal unique identifier (UUID) type is not supported.
        /// </summary>
        RpcSUnsupportedType = 0x000006C4,

        /// <summary>
        /// The tag is invalid.
        /// </summary>
        RpcSInvalidTag = 0x000006C5,

        /// <summary>
        /// The array bounds are invalid.
        /// </summary>
        RpcSInvalidBound = 0x000006C6,

        /// <summary>
        /// The binding does not contain an entry name.
        /// </summary>
        RpcSNoEntryName = 0x000006C7,

        /// <summary>
        /// The name syntax is invalid.
        /// </summary>
        RpcSInvalidNameSyntax = 0x000006C8,

        /// <summary>
        /// The name syntax is not supported.
        /// </summary>
        RpcSUnsupportedNameSyntax = 0x000006C9,

        /// <summary>
        /// No network address is available to use to construct a universal unique identifier (UUID).
        /// </summary>
        RpcSUuidNoAddress = 0x000006CB,

        /// <summary>
        /// The endpoint is a duplicate.
        /// </summary>
        RpcSDuplicateEndpoint = 0x000006CC,

        /// <summary>
        /// The authentication type is unknown.
        /// </summary>
        RpcSUnknownAuthnType = 0x000006CD,

        /// <summary>
        /// The maximum number of calls is too small.
        /// </summary>
        RpcSMaxCallsTooSmall = 0x000006CE,

        /// <summary>
        /// The string is too long.
        /// </summary>
        RpcSStringTooLong = 0x000006CF,

        /// <summary>
        /// The RPC protocol sequence was not found.
        /// </summary>
        RpcSProtseqNotFound = 0x000006D0,

        /// <summary>
        /// The procedure number is out of range.
        /// </summary>
        RpcSProcnumOutOfRange = 0x000006D1,

        /// <summary>
        /// The binding does not contain any authentication information.
        /// </summary>
        RpcSBindingHasNoAuth = 0x000006D2,

        /// <summary>
        /// The authentication service is unknown.
        /// </summary>
        RpcSUnknownAuthnService = 0x000006D3,

        /// <summary>
        /// The authentication level is unknown.
        /// </summary>
        RpcSUnknownAuthnLevel = 0x000006D4,

        /// <summary>
        /// The security context is invalid.
        /// </summary>
        RpcSInvalidAuthIdentity = 0x000006D5,

        /// <summary>
        /// The authorization service is unknown.
        /// </summary>
        RpcSUnknownAuthzService = 0x000006D6,

        /// <summary>
        /// The entry is invalid.
        /// </summary>
        EptSInvalidEntry = 0x000006D7,

        /// <summary>
        /// The server endpoint cannot perform the operation.
        /// </summary>
        EptSCantPerformOp = 0x000006D8,

        /// <summary>
        /// There are no more endpoints available from the endpoint mapper.
        /// </summary>
        EptSNotRegistered = 0x000006D9,

        /// <summary>
        /// No interfaces have been exported.
        /// </summary>
        RpcSNothingToExport = 0x000006DA,

        /// <summary>
        /// The entry name is incomplete.
        /// </summary>
        RpcSIncompleteName = 0x000006DB,

        /// <summary>
        /// The version option is invalid.
        /// </summary>
        RpcSInvalidVersOption = 0x000006DC,

        /// <summary>
        /// There are no more members.
        /// </summary>
        RpcSNoMoreMembers = 0x000006DD,

        /// <summary>
        /// There is nothing to unexport.
        /// </summary>
        RpcSNotAllObjsUnexported = 0x000006DE,

        /// <summary>
        /// The interface was not found.
        /// </summary>
        RpcSInterfaceNotFound = 0x000006DF,

        /// <summary>
        /// The entry already exists.
        /// </summary>
        RpcSEntryAlreadyExists = 0x000006E0,

        /// <summary>
        /// The entry is not found.
        /// </summary>
        RpcSEntryNotFound = 0x000006E1,

        /// <summary>
        /// The name service is unavailable.
        /// </summary>
        RpcSNameServiceUnavailable = 0x000006E2,

        /// <summary>
        /// The network address family is invalid.
        /// </summary>
        RpcSInvalidNafId = 0x000006E3,

        /// <summary>
        /// The requested operation is not supported.
        /// </summary>
        RpcSCannotSupport = 0x000006E4,

        /// <summary>
        /// No security context is available to allow impersonation.
        /// </summary>
        RpcSNoContextAvailable = 0x000006E5,

        /// <summary>
        /// An internal error occurred in a remote procedure call (RPC).
        /// </summary>
        RpcSInternalError = 0x000006E6,

        /// <summary>
        /// The RPC server attempted an integer division by zero.
        /// </summary>
        RpcSZeroDivide = 0x000006E7,

        /// <summary>
        /// An addressing error occurred in the RPC server.
        /// </summary>
        RpcSAddressError = 0x000006E8,

        /// <summary>
        /// A floating-point operation at the RPC server caused a division by zero.
        /// </summary>
        RpcSFpDivZero = 0x000006E9,

        /// <summary>
        /// A floating-point underflow occurred at the RPC server.
        /// </summary>
        RpcSFpUnderflow = 0x000006EA,

        /// <summary>
        /// A floating-point overflow occurred at the RPC server.
        /// </summary>
        RpcSFpOverflow = 0x000006EB,

        /// <summary>
        /// The list of RPC servers available for the binding of auto handles has been exhausted.
        /// </summary>
        RpcXNoMoreEntries = 0x000006EC,

        /// <summary>
        /// Unable to open the character translation table file.
        /// </summary>
        RpcXSsCharTransOpenFail = 0x000006ED,

        /// <summary>
        /// The file containing the character translation table has fewer than 512 bytes.
        /// </summary>
        RpcXSsCharTransShortFile = 0x000006EE,

        /// <summary>
        /// A null context handle was passed from the client to the host during a remote procedure call.
        /// </summary>
        RpcXSsInNullContext = 0x000006EF,

        /// <summary>
        /// The context handle changed during a remote procedure call.
        /// </summary>
        RpcXSsContextDamaged = 0x000006F1,

        /// <summary>
        /// The binding handles passed to a remote procedure call do not match.
        /// </summary>
        RpcXSsHandlesMismatch = 0x000006F2,

        /// <summary>
        /// The stub is unable to get the remote procedure call handle.
        /// </summary>
        RpcXSsCannotGetCallHandle = 0x000006F3,

        /// <summary>
        /// A null reference pointer was passed to the stub.
        /// </summary>
        RpcXNullRefPointer = 0x000006F4,

        /// <summary>
        /// The enumeration value is out of range.
        /// </summary>
        RpcXEnumValueOutOfRange = 0x000006F5,

        /// <summary>
        /// The byte count is too small.
        /// </summary>
        RpcXByteCountTooSmall = 0x000006F6,

        /// <summary>
        /// The stub received bad data.
        /// </summary>
        RpcXBadStubData = 0x000006F7,

        /// <summary>
        /// The supplied user buffer is not valid for the requested operation.
        /// </summary>
        InvalidUserBuffer = 0x000006F8,

        /// <summary>
        /// The disk media is not recognized. It may not be formatted.
        /// </summary>
        UnrecognizedMedia = 0x000006F9,

        /// <summary>
        /// The workstation does not have a trust secret.
        /// </summary>
        NoTrustLsaSecret = 0x000006FA,

        /// <summary>
        /// The security database on the server does not have a computer account for this workstation trust relationship.
        /// </summary>
        NoTrustSamAccount = 0x000006FB,

        /// <summary>
        /// The trust relationship between the primary domain and the trusted domain failed.
        /// </summary>
        TrustedDomainFailure = 0x000006FC,

        /// <summary>
        /// The network logon failed.
        /// </summary>
        TrustFailure = 0x000006FE,

        /// <summary>
        /// A remote procedure call is already in progress for this thread.
        /// </summary>
        RpcSCallInProgress = 0x000006FF,

        /// <summary>
        /// An attempt was made to logon, but the network logon service was not started.
        /// </summary>
        NetlogonNotStarted = 0x00000700,

        /// <summary>
        /// The user's account has expired.
        /// </summary>
        AccountExpired = 0x00000701,

        /// <summary>
        /// The specified port is unknown.
        /// </summary>
        UnknownPort = 0x00000704,

        /// <summary>
        /// The printer driver is unknown.
        /// </summary>
        UnknownPrinterDriver = 0x00000705,

        /// <summary>
        /// The print processor is unknown.
        /// </summary>
        UnknownPrintprocessor = 0x00000706,

        /// <summary>
        /// The specified separator file is invalid.
        /// </summary>
        InvalidSeparatorFile = 0x00000707,

        /// <summary>
        /// The specified priority is invalid.
        /// </summary>
        InvalidPriority = 0x00000708,

        /// <summary>
        /// The printer name is invalid.
        /// </summary>
        InvalidPrinterName = 0x00000709,

        /// <summary>
        /// The printer already exists.
        /// </summary>
        PrinterAlreadyExists = 0x0000070A,

        /// <summary>
        /// The printer command is invalid.
        /// </summary>
        InvalidPrinterCommand = 0x0000070B,

        /// <summary>
        /// The specified datatype is invalid.
        /// </summary>
        InvalidDatatype = 0x0000070C,

        /// <summary>
        /// The environment specified is invalid.
        /// </summary>
        InvalidEnvironment = 0x0000070D,

        /// <summary>
        /// There are no more bindings.
        /// </summary>
        RpcSNoMoreBindings = 0x0000070E,

        /// <summary>
        /// The name or security ID (SID) of the domain specified is inconsistent with the trust information for that domain.
        /// </summary>
        DomainTrustInconsistent = 0x00000712,

        /// <summary>
        /// The server is in use and cannot be unloaded.
        /// </summary>
        ServerHasOpenHandles = 0x00000713,

        /// <summary>
        /// The specified image file did not contain a resource section.
        /// </summary>
        ResourceDataNotFound = 0x00000714,

        /// <summary>
        /// The specified resource type cannot be found in the image file.
        /// </summary>
        ResourceTypeNotFound = 0x00000715,

        /// <summary>
        /// The specified resource name cannot be found in the image file.
        /// </summary>
        ResourceNameNotFound = 0x00000716,

        /// <summary>
        /// The specified resource language ID cannot be found in the image file.
        /// </summary>
        ResourceLangNotFound = 0x00000717,

        /// <summary>
        /// Not enough quota is available to process this command.
        /// </summary>
        NotEnoughQuota = 0x00000718,

        /// <summary>
        /// No interfaces have been registered.
        /// </summary>
        RpcSNoInterfaces = 0x00000719,

        /// <summary>
        /// The remote procedure call was cancelled.
        /// </summary>
        RpcSCallCancelled = 0x0000071A,

        /// <summary>
        /// The binding handle does not contain all required information.
        /// </summary>
        RpcSBindingIncomplete = 0x0000071B,

        /// <summary>
        /// A communications failure occurred during a remote procedure call.
        /// </summary>
        RpcSCommFailure = 0x0000071C,

        /// <summary>
        /// The requested authentication level is not supported.
        /// </summary>
        RpcSUnsupportedAuthnLevel = 0x0000071D,

        /// <summary>
        /// No principal name registered.
        /// </summary>
        RpcSNoPrincName = 0x0000071E,

        /// <summary>
        /// The error specified is not a valid Windows RPC error code.
        /// </summary>
        RpcSNotRpcError = 0x0000071F,

        /// <summary>
        /// A UUID that is valid only on this computer has been allocated.
        /// </summary>
        RpcSUuidLocalOnly = 0x00000720,

        /// <summary>
        /// A security package specific error occurred.
        /// </summary>
        RpcSSecPkgError = 0x00000721,

        /// <summary>
        /// Thread is not canceled.
        /// </summary>
        RpcSNotCancelled = 0x00000722,

        /// <summary>
        /// Invalid operation on the encoding/decoding handle.
        /// </summary>
        RpcXInvalidEsAction = 0x00000723,

        /// <summary>
        /// Incompatible version of the serializing package.
        /// </summary>
        RpcXWrongEsVersion = 0x00000724,

        /// <summary>
        /// Incompatible version of the RPC stub.
        /// </summary>
        RpcXWrongStubVersion = 0x00000725,

        /// <summary>
        /// The RPC pipe object is invalid or corrupted.
        /// </summary>
        RpcXInvalidPipeObject = 0x00000726,

        /// <summary>
        /// An invalid operation was attempted on an RPC pipe object.
        /// </summary>
        RpcXWrongPipeOrder = 0x00000727,

        /// <summary>
        /// Unsupported RPC pipe version.
        /// </summary>
        RpcXWrongPipeVersion = 0x00000728,

        /// <summary>
        /// HTTP proxy server rejected the connection because the cookie authentication failed.
        /// </summary>
        RpcSCookieAuthFailed = 0x00000729,

        /// <summary>
        /// The group member was not found.
        /// </summary>
        RpcSGroupMemberNotFound = 0x0000076A,

        /// <summary>
        /// The endpoint mapper database entry could not be created.
        /// </summary>
        EptSCantCreate = 0x0000076B,

        /// <summary>
        /// The object universal unique identifier (UUID) is the nil UUID.
        /// </summary>
        RpcSInvalidObject = 0x0000076C,

        /// <summary>
        /// The specified time is invalid.
        /// </summary>
        InvalidTime = 0x0000076D,

        /// <summary>
        /// The specified form name is invalid.
        /// </summary>
        InvalidFormName = 0x0000076E,

        /// <summary>
        /// The specified form size is invalid.
        /// </summary>
        InvalidFormSize = 0x0000076F,

        /// <summary>
        /// The specified printer handle is already being waited on
        /// </summary>
        AlreadyWaiting = 0x00000770,

        /// <summary>
        /// The specified printer has been deleted.
        /// </summary>
        PrinterDeleted = 0x00000771,

        /// <summary>
        /// The state of the printer is invalid.
        /// </summary>
        InvalidPrinterState = 0x00000772,

        /// <summary>
        /// The user's password must be changed before signing in.
        /// </summary>
        PasswordMustChange = 0x00000773,

        /// <summary>
        /// The referenced account is currently locked out and may not be logged on to.
        /// </summary>
        AccountLockedOut = 0x00000775,

        /// <summary>
        /// The object exporter specified was not found.
        /// </summary>
        OrInvalidOxid = 0x00000776,

        /// <summary>
        /// The object specified was not found.
        /// </summary>
        OrInvalidOid = 0x00000777,

        /// <summary>
        /// The object resolver set specified was not found.
        /// </summary>
        OrInvalidSet = 0x00000778,

        /// <summary>
        /// Some data remains to be sent in the request buffer.
        /// </summary>
        RpcSSendIncomplete = 0x00000779,

        /// <summary>
        /// Invalid asynchronous remote procedure call handle.
        /// </summary>
        RpcSInvalidAsyncHandle = 0x0000077A,

        /// <summary>
        /// Invalid asynchronous RPC call handle for this operation.
        /// </summary>
        RpcSInvalidAsyncCall = 0x0000077B,

        /// <summary>
        /// The RPC pipe object has already been closed.
        /// </summary>
        RpcXPipeClosed = 0x0000077C,

        /// <summary>
        /// The RPC call completed before all pipes were processed.
        /// </summary>
        RpcXPipeDisciplineError = 0x0000077D,

        /// <summary>
        /// No more data is available from the RPC pipe.
        /// </summary>
        RpcXPipeEmpty = 0x0000077E,

        /// <summary>
        /// No site name is available for this machine.
        /// </summary>
        NoSitename = 0x0000077F,

        /// <summary>
        /// The file cannot be accessed by the system.
        /// </summary>
        CantAccessFile = 0x00000780,

        /// <summary>
        /// The name of the file cannot be resolved by the system.
        /// </summary>
        CantResolveFilename = 0x00000781,

        /// <summary>
        /// The entry is not of the expected type.
        /// </summary>
        RpcSEntryTypeMismatch = 0x00000782,

        /// <summary>
        /// Not all object UUIDs could be exported to the specified entry.
        /// </summary>
        RpcSNotAllObjsExported = 0x00000783,

        /// <summary>
        /// Interface could not be exported to the specified entry.
        /// </summary>
        RpcSInterfaceNotExported = 0x00000784,

        /// <summary>
        /// The specified profile entry could not be added.
        /// </summary>
        RpcSProfileNotAdded = 0x00000785,

        /// <summary>
        /// The specified profile element could not be added.
        /// </summary>
        RpcSPrfEltNotAdded = 0x00000786,

        /// <summary>
        /// The specified profile element could not be removed.
        /// </summary>
        RpcSPrfEltNotRemoved = 0x00000787,

        /// <summary>
        /// The group element could not be added.
        /// </summary>
        RpcSGrpEltNotAdded = 0x00000788,

        /// <summary>
        /// The group element could not be removed.
        /// </summary>
        RpcSGrpEltNotRemoved = 0x00000789,

        /// <summary>
        /// The printer driver is not compatible with a policy enabled on your computer that blocks NT 4.0 drivers.
        /// </summary>
        KmDriverBlocked = 0x0000078A,

        /// <summary>
        /// The context has expired and can no longer be used.
        /// </summary>
        ContextExpired = 0x0000078B,

        /// <summary>
        /// Authentication failed because NTLM authentication has been disabled.
        /// </summary>
        NtlmBlocked = 0x00000791,

        /// <summary>
        /// Logon Failure: EAS policy requires that the user change their password before this operation can be performed.
        /// </summary>
        PasswordChangeRequired = 0x00000792,

        /// <summary>
        /// The pixel format is invalid.
        /// </summary>
        InvalidPixelFormat = 0x000007D0,

        /// <summary>
        /// The specified driver is invalid.
        /// </summary>
        BadDriver = 0x000007D1,

        /// <summary>
        /// The window style or class attribute is invalid for this operation.
        /// </summary>
        InvalidWindowStyle = 0x000007D2,

        /// <summary>
        /// The requested metafile operation is not supported.
        /// </summary>
        MetafileNotSupported = 0x000007D3,

        /// <summary>
        /// The requested transformation operation is not supported.
        /// </summary>
        TransformNotSupported = 0x000007D4,

        /// <summary>
        /// The requested clipping operation is not supported.
        /// </summary>
        ClippingNotSupported = 0x000007D5,

        /// <summary>
        /// The specified color management module is invalid.
        /// </summary>
        InvalidCmm = 0x000007DA,

        /// <summary>
        /// The specified color profile is invalid.
        /// </summary>
        InvalidProfile = 0x000007DB,

        /// <summary>
        /// The specified tag was not found.
        /// </summary>
        TagNotFound = 0x000007DC,

        /// <summary>
        /// A required tag is not present.
        /// </summary>
        TagNotPresent = 0x000007DD,

        /// <summary>
        /// The specified tag is already present.
        /// </summary>
        DuplicateTag = 0x000007DE,

        /// <summary>
        /// The specified color profile was not found.
        /// </summary>
        ProfileNotFound = 0x000007E0,

        /// <summary>
        /// The specified color space is invalid.
        /// </summary>
        InvalidColorspace = 0x000007E1,

        /// <summary>
        /// Image Color Management is not enabled.
        /// </summary>
        IcmNotEnabled = 0x000007E2,

        /// <summary>
        /// There was an error while deleting the color transform.
        /// </summary>
        DeletingIcmXform = 0x000007E3,

        /// <summary>
        /// The specified color transform is invalid.
        /// </summary>
        InvalidTransform = 0x000007E4,

        /// <summary>
        /// The specified transform does not match the bitmap's color space.
        /// </summary>
        ColorspaceMismatch = 0x000007E5,

        /// <summary>
        /// The specified named color index is not present in the profile.
        /// </summary>
        InvalidColorindex = 0x000007E6,

        /// <summary>
        /// The network connection was made successfully, but the user had to be prompted for a password other than the one originally specified.
        /// </summary>
        ConnectedOtherPassword = 0x0000083C,

        /// <summary>
        /// The specified username is invalid.
        /// </summary>
        BadUsername = 0x0000089A,

        /// <summary>
        /// This network connection does not exist.
        /// </summary>
        NotConnected = 0x000008CA,

        /// <summary>
        /// This network connection has files open or requests pending.
        /// </summary>
        OpenFiles = 0x00000961,

        /// <summary>
        /// Active connections still exist.
        /// </summary>
        ActiveConnections = 0x00000962,

        /// <summary>
        /// The device is in use by an active process and cannot be disconnected.
        /// </summary>
        DeviceInUse = 0x00000964,

        /// <summary>
        /// The specified print monitor is unknown.
        /// </summary>
        UnknownPrintMonitor = 0x00000BB8,

        /// <summary>
        /// The specified printer driver is currently in use.
        /// </summary>
        PrinterDriverInUse = 0x00000BB9,

        /// <summary>
        /// The spool file was not found.
        /// </summary>
        SpoolFileNotFound = 0x00000BBA,

        /// <summary>
        /// A StartDocPrinter call was not issued.
        /// </summary>
        SplNoStartdoc = 0x00000BBB,

        /// <summary>
        /// An AddJob call was not issued.
        /// </summary>
        SplNoAddjob = 0x00000BBC,

        /// <summary>
        /// The specified print monitor does not have the required functions.
        /// </summary>
        InvalidPrintMonitor = 0x00000BBF,

        /// <summary>
        /// The specified print monitor is currently in use.
        /// </summary>
        PrintMonitorInUse = 0x00000BC0,

        /// <summary>
        /// The requested operation is not allowed when there are jobs queued to the printer.
        /// </summary>
        PrinterHasJobsQueued = 0x00000BC1,

        /// <summary>
        /// The requested operation is successful. Changes will not be effective until the system is rebooted.
        /// </summary>
        SuccessRebootRequired = 0x00000BC2,

        /// <summary>
        /// The requested operation is successful. Changes will not be effective until the service is restarted.
        /// </summary>
        SuccessRestartRequired = 0x00000BC3,

        /// <summary>
        /// No printers were found.
        /// </summary>
        PrinterNotFound = 0x00000BC4,

        /// <summary>
        /// The printer driver is known to be unreliable.
        /// </summary>
        PrinterDriverWarned = 0x00000BC5,

        /// <summary>
        /// The printer driver is known to harm the system.
        /// </summary>
        PrinterDriverBlocked = 0x00000BC6,

        /// <summary>
        /// The requested operation failed. A system reboot is required to roll back changes made.
        /// </summary>
        FailRebootRequired = 0x00000BC9,

        /// <summary>
        /// The requested operation failed. A system reboot has been initiated to roll back changes made.
        /// </summary>
        FailRebootInitiated = 0x00000BCA,

        /// <summary>
        /// The specified printer cannot be shared.
        /// </summary>
        PrinterNotShareable = 0x00000BCE,

        /// <summary>
        /// The operation was paused.
        /// </summary>
        RequestPaused = 0x00000BEA,

        /// <summary>
        /// Reissue the given operation as a cached IO operation
        /// </summary>
        IoReissueAsCached = 0x00000F6E,

        /// <summary>
        /// WINS encountered an error while processing the command.
        /// </summary>
        WinsInternal = 0x00000FA0,

        /// <summary>
        /// The local WINS cannot be deleted.
        /// </summary>
        CanNotDelLocalWins = 0x00000FA1,

        /// <summary>
        /// The importation from the file failed.
        /// </summary>
        StaticInit = 0x00000FA2,

        /// <summary>
        /// The backup failed. Was a full backup done before?
        /// </summary>
        IncBackup = 0x00000FA3,

        /// <summary>
        /// The backup failed. Check the directory to which you are backing the database.
        /// </summary>
        FullBackup = 0x00000FA4,

        /// <summary>
        /// The name does not exist in the WINS database.
        /// </summary>
        RecNonExistent = 0x00000FA5,

        /// <summary>
        /// Replication with a nonconfigured partner is not allowed.
        /// </summary>
        RplNotAllowed = 0x00000FA6,

        /// <summary>
        /// The requested data cannot be found in local or peer caches.
        /// </summary>
        PeerdistMissingData = 0x00000FD4,

        /// <summary>
        /// No more data is available or required.
        /// </summary>
        PeerdistNoMore = 0x00000FD5,

        /// <summary>
        /// The supplied object has not been initialized.
        /// </summary>
        PeerdistNotInitialized = 0x00000FD6,

        /// <summary>
        /// The supplied object has already been invalidated.
        /// </summary>
        PeerdistInvalidated = 0x00000FD9,

        /// <summary>
        /// An element already exists and was not replaced.    /// </summary>
        PeerdistAlreadyExists = 0x00000FDA,

        /// <summary>
        /// An operation accessed data beyond the bounds of valid data.
        /// </summary>
        PeerdistOutOfBounds = 0x00000FDD,

        /// <summary>
        /// The SKU is not licensed.
        /// </summary>
        PeerdistNotLicensed = 0x00000FE0,

        /// <summary>
        /// Communication with one or more computers will be temporarily blocked due to recent errors.
        /// </summary>
        PeerdistTrustFailure = 0x00000FE2,

        /// <summary>
        /// The DHCP client has obtained an IP address that is already in use on the network. The local interface will be disabled until the DHCP client can obtain a new address.
        /// </summary>
        DhcpAddressConflict = 0x00001004,

        /// <summary>
        /// The GUID passed was not recognized as valid by a WMI data provider.
        /// </summary>
        WmiGuidNotFound = 0x00001068,

        /// <summary>
        /// The instance name passed was not recognized as valid by a WMI data provider.
        /// </summary>
        WmiInstanceNotFound = 0x00001069,

        /// <summary>
        /// The data item ID passed was not recognized as valid by a WMI data provider.
        /// </summary>
        WmiItemidNotFound = 0x0000106A,

        /// <summary>
        /// The WMI request could not be completed and should be retried.
        /// </summary>
        WmiTryAgain = 0x0000106B,

        /// <summary>
        /// The WMI data provider could not be located.
        /// </summary>
        WmiDpNotFound = 0x0000106C,

        /// <summary>
        /// The WMI data block or event notification has already been enabled.
        /// </summary>
        WmiAlreadyEnabled = 0x0000106E,

        /// <summary>
        /// The WMI data block is no longer available.
        /// </summary>
        WmiGuidDisconnected = 0x0000106F,

        /// <summary>
        /// The WMI data service is not available.
        /// </summary>
        WmiServerUnavailable = 0x00001070,

        /// <summary>
        /// The WMI data provider failed to carry out the request.
        /// </summary>
        WmiDpFailed = 0x00001071,

        /// <summary>
        /// The WMI MOF information is not valid.
        /// </summary>
        WmiInvalidMof = 0x00001072,

        /// <summary>
        /// The WMI registration information is not valid.
        /// </summary>
        WmiInvalidReginfo = 0x00001073,

        /// <summary>
        /// The WMI data block or event notification has already been disabled.
        /// </summary>
        WmiAlreadyDisabled = 0x00001074,

        /// <summary>
        /// The WMI data item or data block is read only.
        /// </summary>
        WmiReadOnly = 0x00001075,

        /// <summary>
        /// The WMI data item or data block could not be changed.
        /// </summary>
        WmiSetFailure = 0x00001076,

        /// <summary>
        /// This operation is only valid in the context of an app container.
        /// </summary>
        NotAppcontainer = 0x0000109A,

        /// <summary>
        /// This application can only run in the context of an app container.
        /// </summary>
        AppcontainerRequired = 0x0000109B,

        /// <summary>
        /// The media identifier does not represent a valid medium.
        /// </summary>
        InvalidMedia = 0x000010CC,

        /// <summary>
        /// The library identifier does not represent a valid library.
        /// </summary>
        InvalidLibrary = 0x000010CD,

        /// <summary>
        /// The media pool identifier does not represent a valid media pool.
        /// </summary>
        InvalidMediaPool = 0x000010CE,

        /// <summary>
        /// The drive and medium are not compatible or exist in different libraries.
        /// </summary>
        DriveMediaMismatch = 0x000010CF,

        /// <summary>
        /// The medium currently exists in an offline library and must be online to perform this operation.
        /// </summary>
        MediaOffline = 0x000010D0,

        /// <summary>
        /// The operation cannot be performed on an offline library.
        /// </summary>
        LibraryOffline = 0x000010D1,

        /// <summary>
        /// The library, drive, or media pool is empty.
        /// </summary>
        Empty = 0x000010D2,

        /// <summary>
        /// The library, drive, or media pool must be empty to perform this operation.
        /// </summary>
        NotEmpty = 0x000010D3,

        /// <summary>
        /// No media is currently available in this media pool or library.
        /// </summary>
        MediaUnavailable = 0x000010D4,

        /// <summary>
        /// A resource required for this operation is disabled.
        /// </summary>
        ResourceDisabled = 0x000010D5,

        /// <summary>
        /// The media identifier does not represent a valid cleaner.
        /// </summary>
        InvalidCleaner = 0x000010D6,

        /// <summary>
        /// The drive cannot be cleaned or does not support cleaning.
        /// </summary>
        UnableToClean = 0x000010D7,

        /// <summary>
        /// The object identifier does not represent a valid object.
        /// </summary>
        ObjectNotFound = 0x000010D8,

        /// <summary>
        /// Unable to read from or write to the database.
        /// </summary>
        DatabaseFailure = 0x000010D9,

        /// <summary>
        /// The database is full.
        /// </summary>
        DatabaseFull = 0x000010DA,

        /// <summary>
        /// The medium is not compatible with the device or media pool.
        /// </summary>
        MediaIncompatible = 0x000010DB,

        /// <summary>
        /// The resource required for this operation does not exist.
        /// </summary>
        ResourceNotPresent = 0x000010DC,

        /// <summary>
        /// The operation identifier is not valid.
        /// </summary>
        InvalidOperation = 0x000010DD,

        /// <summary>
        /// The media is not mounted or ready for use.
        /// </summary>
        MediaNotAvailable = 0x000010DE,

        /// <summary>
        /// The device is not ready for use.
        /// </summary>
        DeviceNotAvailable = 0x000010DF,

        /// <summary>
        /// The operator or administrator has refused the request.
        /// </summary>
        RequestRefused = 0x000010E0,

        /// <summary>
        /// The drive identifier does not represent a valid drive.
        /// </summary>
        InvalidDriveObject = 0x000010E1,

        /// <summary>
        /// Library is full. No slot is available for use.
        /// </summary>
        LibraryFull = 0x000010E2,

        /// <summary>
        /// The transport cannot access the medium.
        /// </summary>
        MediumNotAccessible = 0x000010E3,

        /// <summary>
        /// Unable to load the medium into the drive.
        /// </summary>
        UnableToLoadMedium = 0x000010E4,

        /// <summary>
        /// Unable to retrieve the drive status.
        /// </summary>
        UnableToInventoryDrive = 0x000010E5,

        /// <summary>
        /// Unable to retrieve the slot status.
        /// </summary>
        UnableToInventorySlot = 0x000010E6,

        /// <summary>
        /// Cannot use the transport because it is already in use.
        /// </summary>
        TransportFull = 0x000010E8,

        /// <summary>
        /// Unable to open or close the inject/eject port.
        /// </summary>
        ControllingIeport = 0x000010E9,

        /// <summary>
        /// A cleaner slot is already reserved.
        /// </summary>
        CleanerSlotSet = 0x000010EB,

        /// <summary>
        /// A cleaner slot is not reserved.
        /// </summary>
        CleanerSlotNotSet = 0x000010EC,

        /// <summary>
        /// The cleaner cartridge has performed the maximum number of drive cleanings.
        /// </summary>
        CleanerCartridgeSpent = 0x000010ED,

        /// <summary>
        /// Unexpected on-medium identifier.
        /// </summary>
        UnexpectedOmid = 0x000010EE,

        /// <summary>
        /// The last remaining item in this group or resource cannot be deleted.
        /// </summary>
        CantDeleteLastItem = 0x000010EF,

        /// <summary>
        /// The message provided exceeds the maximum size allowed for this parameter.
        /// </summary>
        MessageExceedsMaxSize = 0x000010F0,

        /// <summary>
        /// The volume contains system or paging files.
        /// </summary>
        VolumeContainsSysFiles = 0x000010F1,

        /// <summary>
        /// The media type cannot be removed from this library since at least one drive in the library reports it can support this media type.
        /// </summary>
        IndigenousType = 0x000010F2,

        /// <summary>
        /// This offline media cannot be mounted on this system since no enabled drives are present which can be used.
        /// </summary>
        NoSupportingDrives = 0x000010F3,

        /// <summary>
        /// Cannot use the inject/eject port because it is not empty.
        /// </summary>
        IeportFull = 0x000010F5,

        /// <summary>
        /// This file is currently not available for use on this computer.
        /// </summary>
        FileOffline = 0x000010FE,

        /// <summary>
        /// The remote storage service is not operational at this time.
        /// </summary>
        RemoteStorageNotActive = 0x000010FF,

        /// <summary>
        /// The file or directory is not a reparse point.
        /// </summary>
        NotAReparsePoint = 0x00001126,

        /// <summary>
        /// The data present in the reparse point buffer is invalid.
        /// </summary>
        InvalidReparseData = 0x00001128,

        /// <summary>
        /// The tag present in the reparse point buffer is invalid.
        /// </summary>
        ReparseTagInvalid = 0x00001129,

        /// <summary>
        /// There is a mismatch between the tag specified in the request and the tag present in the reparse point.
        /// </summary>
        ReparseTagMismatch = 0x0000112A,

        /// <summary>
        /// Fast Cache data not found.
        /// </summary>
        AppDataNotFound = 0x00001130,

        /// <summary>
        /// Fast Cache data expired.
        /// </summary>
        AppDataExpired = 0x00001131,

        /// <summary>
        /// Fast Cache data corrupt.
        /// </summary>
        AppDataCorrupt = 0x00001132,

        /// <summary>
        /// Fast Cache data has exceeded its max size and cannot be updated.
        /// </summary>
        AppDataLimitExceeded = 0x00001133,

        /// <summary>
        /// Fast Cache has been ReArmed and requires a reboot until it can be updated.
        /// </summary>
        AppDataRebootRequired = 0x00001134,

        /// <summary>
        /// The Secure Boot policy is invalid.
        /// </summary>
        SecurebootInvalidPolicy = 0x00001146,

        /// <summary>
        /// Secure Boot is not enabled on this machine.
        /// </summary>
        SecurebootNotEnabled = 0x00001149,

        /// <summary>
        /// Secure Boot requires that certain files and drivers are not replaced by other files or drivers.
        /// </summary>
        SecurebootFileReplaced = 0x0000114A,

        /// <summary>
        /// Single Instance Storage is not available on this volume.
        /// </summary>
        VolumeNotSisEnabled = 0x00001194,

        /// <summary>
        /// The operation cannot be completed because other resources are dependent on this resource.
        /// </summary>
        DependentResourceExists = 0x00001389,

        /// <summary>
        /// The cluster resource dependency cannot be found.
        /// </summary>
        DependencyNotFound = 0x0000138A,

        /// <summary>
        /// The cluster resource cannot be made dependent on the specified resource because it is already dependent.
        /// </summary>
        DependencyAlreadyExists = 0x0000138B,

        /// <summary>
        /// The cluster resource is not online.
        /// </summary>
        ResourceNotOnline = 0x0000138C,

        /// <summary>
        /// A cluster node is not available for this operation.
        /// </summary>
        HostNodeNotAvailable = 0x0000138D,

        /// <summary>
        /// The cluster resource is not available.
        /// </summary>
        ResourceNotAvailable = 0x0000138E,

        /// <summary>
        /// The cluster resource could not be found.
        /// </summary>
        ResourceNotFound = 0x0000138F,

        /// <summary>
        /// The cluster is being shut down.
        /// </summary>
        ShutdownCluster = 0x00001390,

        /// <summary>
        /// A cluster node cannot be evicted from the cluster unless the node is down or it is the last node.
        /// </summary>
        CantEvictActiveNode = 0x00001391,

        /// <summary>
        /// The object already exists.
        /// </summary>
        ObjectAlreadyExists = 0x00001392,

        /// <summary>
        /// The object is already in the list.
        /// </summary>
        ObjectInList = 0x00001393,

        /// <summary>
        /// The cluster group is not available for any new requests.
        /// </summary>
        GroupNotAvailable = 0x00001394,

        /// <summary>
        /// The cluster group could not be found.
        /// </summary>
        GroupNotFound = 0x00001395,

        /// <summary>
        /// The operation could not be completed because the cluster group is not online.
        /// </summary>
        GroupNotOnline = 0x00001396,

        /// <summary>
        /// The operation failed because either the specified cluster node is not the owner of the group, or the node is not a possible owner of the group.
        /// </summary>
        HostNodeNotGroupOwner = 0x00001398,

        /// <summary>
        /// The cluster resource could not be created in the specified resource monitor.
        /// </summary>
        ResmonCreateFailed = 0x00001399,

        /// <summary>
        /// The cluster resource could not be brought online by the resource monitor.
        /// </summary>
        ResmonOnlineFailed = 0x0000139A,

        /// <summary>
        /// The operation could not be completed because the cluster resource is online.
        /// </summary>
        ResourceOnline = 0x0000139B,

        /// <summary>
        /// The cluster resource could not be deleted or brought offline because it is the quorum resource.
        /// </summary>
        QuorumResource = 0x0000139C,

        /// <summary>
        /// The cluster could not make the specified resource a quorum resource because it is not capable of being a quorum resource.
        /// </summary>
        NotQuorumCapable = 0x0000139D,

        /// <summary>
        /// The cluster software is shutting down.
        /// </summary>
        ClusterShuttingDown = 0x0000139E,

        /// <summary>
        /// The group or resource is not in the correct state to perform the requested operation.
        /// </summary>
        InvalidState = 0x0000139F,

        /// <summary>
        /// The cluster could not make the specified resource a quorum resource because it does not belong to a shared storage class.
        /// </summary>
        NotQuorumClass = 0x000013A1,

        /// <summary>
        /// The cluster resource could not be deleted since it is a core resource.
        /// </summary>
        CoreResource = 0x000013A2,

        /// <summary>
        /// The quorum log could not be created or mounted successfully.
        /// </summary>
        QuorumlogOpenFailed = 0x000013A4,

        /// <summary>
        /// The cluster log is corrupt.
        /// </summary>
        ClusterlogCorrupt = 0x000013A5,

        /// <summary>
        /// The cluster node failed to take control of the quorum resource because the resource is owned by another active node.
        /// </summary>
        QuorumOwnerAlive = 0x000013AA,

        /// <summary>
        /// A cluster network is not available for this operation.
        /// </summary>
        NetworkNotAvailable = 0x000013AB,

        /// <summary>
        /// A cluster node is not available for this operation.
        /// </summary>
        NodeNotAvailable = 0x000013AC,

        /// <summary>
        /// All cluster nodes must be running to perform this operation.
        /// </summary>
        AllNodesNotAvailable = 0x000013AD,

        /// <summary>
        /// A cluster resource failed.
        /// </summary>
        ResourceFailed = 0x000013AE,

        /// <summary>
        /// The cluster node is not valid.
        /// </summary>
        ClusterInvalidNode = 0x000013AF,

        /// <summary>
        /// The cluster node already exists.
        /// </summary>
        ClusterNodeExists = 0x000013B0,

        /// <summary>
        /// A node is in the process of joining the cluster.
        /// </summary>
        ClusterJoinInProgress = 0x000013B1,

        /// <summary>
        /// The cluster node was not found.
        /// </summary>
        ClusterNodeNotFound = 0x000013B2,

        /// <summary>
        /// The cluster network already exists.
        /// </summary>
        ClusterNetworkExists = 0x000013B4,

        /// <summary>
        /// The cluster network was not found.
        /// </summary>
        ClusterNetworkNotFound = 0x000013B5,

        /// <summary>
        /// The cluster request is not valid for this object.
        /// </summary>
        ClusterInvalidRequest = 0x000013B8,

        /// <summary>
        /// The cluster node is down.
        /// </summary>
        ClusterNodeDown = 0x000013BA,

        /// <summary>
        /// The cluster node is not reachable.
        /// </summary>
        ClusterNodeUnreachable = 0x000013BB,

        /// <summary>
        /// The cluster node is not a member of the cluster.
        /// </summary>
        ClusterNodeNotMember = 0x000013BC,

        /// <summary>
        /// The cluster network is not valid.
        /// </summary>
        ClusterInvalidNetwork = 0x000013BE,

        /// <summary>
        /// The cluster node is up.
        /// </summary>
        ClusterNodeUp = 0x000013C0,

        /// <summary>
        /// The cluster IP address is already in use.
        /// </summary>
        ClusterIpaddrInUse = 0x000013C1,

        /// <summary>
        /// The cluster node is not paused.
        /// </summary>
        ClusterNodeNotPaused = 0x000013C2,

        /// <summary>
        /// The cluster node is already up.
        /// </summary>
        ClusterNodeAlreadyUp = 0x000013C5,

        /// <summary>
        /// The cluster node is already down.
        /// </summary>
        ClusterNodeAlreadyDown = 0x000013C6,

        /// <summary>
        /// The cluster quorum resource is not allowed to have any dependencies.
        /// </summary>
        DependencyNotAllowed = 0x000013CD,

        /// <summary>
        /// The cluster node is paused.
        /// </summary>
        ClusterNodePaused = 0x000013CE,

        /// <summary>
        /// The cluster resource cannot be brought online. The owner node cannot run this resource.
        /// </summary>
        NodeCantHostResource = 0x000013CF,

        /// <summary>
        /// The cluster node is not ready to perform the requested operation.
        /// </summary>
        ClusterNodeNotReady = 0x000013D0,

        /// <summary>
        /// The cluster join operation was aborted.
        /// </summary>
        ClusterJoinAborted = 0x000013D2,

        /// <summary>
        /// The specified resource name is not supported by this resource DLL. This may be due to a bad (or changed) name supplied to the resource DLL.
        /// </summary>
        ClusterResnameNotFound = 0x000013D8,

        /// <summary>
        /// The resource monitor will not allow the fail operation to be performed while the resource is in its current state. This may happen if the resource is in a pending state.
        /// </summary>
        ResmonInvalidState = 0x000013DC,

        /// <summary>
        /// A non locker code got a request to reserve the lock for making global updates.
        /// </summary>
        ClusterGumNotLocker = 0x000013DD,

        /// <summary>
        /// The quorum disk could not be located by the cluster service.
        /// </summary>
        QuorumDiskNotFound = 0x000013DE,

        /// <summary>
        /// The backed up cluster database is possibly corrupt.
        /// </summary>
        DatabaseBackupCorrupt = 0x000013DF,

        /// <summary>
        /// This operation is not supported on a cluster without an Administrator Access Point.
        /// </summary>
        NoAdminAccessPoint = 0x000013E2,

        /// <summary>
        /// The membership engine requested shutdown of the cluster service on this node.
        /// </summary>
        ClusterMembershipHalt = 0x00001704,

        /// <summary>
        /// This computer cannot be made a member of a cluster.
        /// </summary>
        NodeCannotBeClustered = 0x0000170A,

        /// <summary>
        /// This computer cannot be made a member of a cluster because it does not have the correct version of Windows installed.
        /// </summary>
        ClusterWrongOsVersion = 0x0000170B,

        /// <summary>
        /// The cluster configuration action has already been committed.
        /// </summary>
        CluscfgAlreadyCommitted = 0x0000170D,

        /// <summary>
        /// The cluster configuration action could not be rolled back.
        /// </summary>
        CluscfgRollbackFailed = 0x0000170E,

        /// <summary>
        /// One or more nodes in the cluster are running a version of Windows that does not support this operation.
        /// </summary>
        ClusterOldVersion = 0x00001710,

        /// <summary>
        /// No network adapters are available.
        /// </summary>
        ClusterNoNetAdapters = 0x00001712,

        /// <summary>
        /// The cluster node has been poisoned.
        /// </summary>
        ClusterPoisoned = 0x00001713,

        /// <summary>
        /// The group is unable to accept the request since it is moving to another node.
        /// </summary>
        ClusterGroupMoving = 0x00001714,

        /// <summary>
        /// The call to the cluster resource DLL timed out.
        /// </summary>
        ResourceCallTimedOut = 0x00001716,

        /// <summary>
        /// A network error occurred while sending data to another node in the cluster. The number of bytes transmitted was less than required.
        /// </summary>
        ClusterPartialSend = 0x0000171A,

        /// <summary>
        /// An internal cluster error occurred. Data was not properly initialized.
        /// </summary>
        ClusterNullData = 0x00001720,

        /// <summary>
        /// An error occurred while reading from a stream of data. An unexpected number of bytes was returned.
        /// </summary>
        ClusterPartialRead = 0x00001721,

        /// <summary>
        /// An error occurred while writing to a stream of data. The required number of bytes could not be written.
        /// </summary>
        ClusterPartialWrite = 0x00001722,

        /// <summary>
        /// A quorum of cluster nodes was not present to form a cluster.
        /// </summary>
        ClusterNoQuorum = 0x00001725,

        /// <summary>
        /// The Failover Clustering feature is not installed on this node.
        /// </summary>
        ClusterNotInstalled = 0x0000172C,

        /// <summary>
        /// This cluster can not be created since the specified number of nodes exceeds the maximum allowed limit.
        /// </summary>
        ClusterTooManyNodes = 0x0000172F,

        /// <summary>
        /// This cluster cannot be destroyed. It has non-core application groups which must be deleted before the cluster can be destroyed.
        /// </summary>
        NoncoreGroupsFound = 0x00001731,

        /// <summary>
        /// The current operation cannot be performed on this group at this time.
        /// </summary>
        ClusterGroupBusy = 0x00001738,

        /// <summary>
        /// The directory or file is not located on a cluster shared volume.
        /// </summary>
        ClusterNotSharedVolume = 0x00001739,

        /// <summary>
        /// The path does not belong to a cluster shared volume.
        /// </summary>
        NonCsvPath = 0x0000173E,

        /// <summary>
        /// The cluster shared volume is not locally mounted on this node.
        /// </summary>
        CsvVolumeNotLocal = 0x0000173F,

        /// <summary>
        /// The requested operation can not be completed because the group is queued for an operation.
        /// </summary>
        ClusterGroupQueued = 0x00001747,

        /// <summary>
        /// The disk is not configured in a way to be used with CSV. CSV disks must have at least one partition that is formatted with NTFS or REFS.
        /// </summary>
        DiskNotCsvCapable = 0x0000174C,

        /// <summary>
        /// The operation cannot be completed because of cluster affinity conflicts
        /// </summary>
        ClusterAffinityConflict = 0x00001753,

        /// <summary>
        /// The specified file could not be encrypted.
        /// </summary>
        EncryptionFailed = 0x00001770,

        /// <summary>
        /// The specified file could not be decrypted.
        /// </summary>
        DecryptionFailed = 0x00001771,

        /// <summary>
        /// The specified file is encrypted and the user does not have the ability to decrypt it.
        /// </summary>
        FileEncrypted = 0x00001772,

        /// <summary>
        /// There is no valid encryption recovery policy configured for this system.
        /// </summary>
        NoRecoveryPolicy = 0x00001773,

        /// <summary>
        /// The required encryption driver is not loaded for this system.
        /// </summary>
        NoEfs = 0x00001774,

        /// <summary>
        /// The file was encrypted with a different encryption driver than is currently loaded.
        /// </summary>
        WrongEfs = 0x00001775,

        /// <summary>
        /// There are no EFS keys defined for the user.
        /// </summary>
        NoUserKeys = 0x00001776,

        /// <summary>
        /// The specified file is not encrypted.
        /// </summary>
        FileNotEncrypted = 0x00001777,

        /// <summary>
        /// The specified file is not in the defined EFS export format.
        /// </summary>
        NotExportFormat = 0x00001778,

        /// <summary>
        /// The specified file is read only.
        /// </summary>
        FileReadOnly = 0x00001779,

        /// <summary>
        /// The directory has been disabled for encryption.
        /// </summary>
        DirEfsDisallowed = 0x0000177A,

        /// <summary>
        /// The server is not trusted for remote encryption operation.
        /// </summary>
        EfsServerNotTrusted = 0x0000177B,

        /// <summary>
        /// Recovery policy configured for this system contains invalid recovery certificate.
        /// </summary>
        BadRecoveryPolicy = 0x0000177C,

        /// <summary>
        /// The encryption algorithm used on the source file needs a bigger key buffer than the one on the destination file.
        /// </summary>
        EfsAlgBlobTooBig = 0x0000177D,

        /// <summary>
        /// The disk partition does not support file encryption.
        /// </summary>
        VolumeNotSupportEfs = 0x0000177E,

        /// <summary>
        /// This machine is disabled for file encryption.
        /// </summary>
        EfsDisabled = 0x0000177F,

        /// <summary>
        /// A newer system is required to decrypt this encrypted file.
        /// </summary>
        EfsVersionNotSupport = 0x00001780,

        /// <summary>
        /// The list of servers for this workgroup is not currently available
        /// </summary>
        NoBrowserServersFound = 0x000017E6,

        /// <summary>
        /// The Task Scheduler service must be configured to run in the System account to function properly. Individual tasks may be configured to run in other accounts.
        /// </summary>
        SchedEServiceNotLocalsystem = 0x00001838,

        /// <summary>
        /// Log service encountered an invalid log sector.
        /// </summary>
        LogSectorInvalid = 0x000019C8,

        /// <summary>
        /// Log service encountered a log sector with invalid block parity.
        /// </summary>
        LogSectorParityInvalid = 0x000019C9,

        /// <summary>
        /// Log service encountered a remapped log sector.
        /// </summary>
        LogSectorRemapped = 0x000019CA,

        /// <summary>
        /// Log service encountered a partial or incomplete log block.
        /// </summary>
        LogBlockIncomplete = 0x000019CB,

        /// <summary>
        /// Log service encountered an attempt access data outside the active log range.
        /// </summary>
        LogInvalidRange = 0x000019CC,

        /// <summary>
        /// Log service user marshalling buffers are exhausted.
        /// </summary>
        LogBlocksExhausted = 0x000019CD,

        /// <summary>
        /// Log service encountered an attempt read from a marshalling area with an invalid read context.
        /// </summary>
        LogReadContextInvalid = 0x000019CE,

        /// <summary>
        /// Log service encountered an invalid log restart area.
        /// </summary>
        LogRestartInvalid = 0x000019CF,

        /// <summary>
        /// Log service encountered an invalid log block version.
        /// </summary>
        LogBlockVersion = 0x000019D0,

        /// <summary>
        /// Log service encountered an invalid log block.
        /// </summary>
        LogBlockInvalid = 0x000019D1,

        /// <summary>
        /// Log service encountered an attempt to read the log with an invalid read mode.
        /// </summary>
        LogReadModeInvalid = 0x000019D2,

        /// <summary>
        /// Log service encountered a log stream with no restart area.
        /// </summary>
        LogNoRestart = 0x000019D3,

        /// <summary>
        /// Log service encountered a corrupted metadata file.
        /// </summary>
        LogMetadataCorrupt = 0x000019D4,

        /// <summary>
        /// Log service encountered a metadata file that could not be created by the log file system.
        /// </summary>
        LogMetadataInvalid = 0x000019D5,

        /// <summary>
        /// Log service encountered a metadata file with inconsistent data.
        /// </summary>
        LogMetadataInconsistent = 0x000019D6,

        /// <summary>
        /// Log service encountered an attempt to erroneous allocate or dispose reservation space.
        /// </summary>
        LogReservationInvalid = 0x000019D7,

        /// <summary>
        /// Log service cannot delete log file or file system container.
        /// </summary>
        LogCantDelete = 0x000019D8,

        /// <summary>
        /// Log service has attempted to read or write backward past the start of the log.
        /// </summary>
        LogStartOfLog = 0x000019DA,

        /// <summary>
        /// Log policy in question was not installed at the time of the request.
        /// </summary>
        LogPolicyNotInstalled = 0x000019DC,

        /// <summary>
        /// The installed set of policies on the log is invalid.
        /// </summary>
        LogPolicyInvalid = 0x000019DD,

        /// <summary>
        /// A policy on the log in question prevented the operation from completing.
        /// </summary>
        LogPolicyConflict = 0x000019DE,

        /// <summary>
        /// Log space cannot be reclaimed because the log is pinned by the archive tail.
        /// </summary>
        LogPinnedArchiveTail = 0x000019DF,

        /// <summary>
        /// Log record is not a record in the log file.
        /// </summary>
        LogRecordNonexistent = 0x000019E0,

        /// <summary>
        /// An new or existing archive tail or base of the active log is invalid.
        /// </summary>
        LogTailInvalid = 0x000019E3,

        /// <summary>
        /// Log space is exhausted.
        /// </summary>
        LogFull = 0x000019E4,

        /// <summary>
        /// The log could not be set to the requested size.
        /// </summary>
        CouldNotResizeLog = 0x000019E5,

        /// <summary>
        /// Log is multiplexed, no direct writes to the physical log is allowed.
        /// </summary>
        LogMultiplexed = 0x000019E6,

        /// <summary>
        /// The operation failed because the log is a dedicated log.
        /// </summary>
        LogDedicated = 0x000019E7,

        /// <summary>
        /// Log archival is in progress.
        /// </summary>
        LogArchiveInProgress = 0x000019E9,

        /// <summary>
        /// The operation requires a non-ephemeral log, but the log is ephemeral.
        /// </summary>
        LogEphemeral = 0x000019EA,

        /// <summary>
        /// The log must have at least two containers before it can be read from or written to.
        /// </summary>
        LogNotEnoughContainers = 0x000019EB,

        /// <summary>
        /// A log client has not been registered on the stream.
        /// </summary>
        LogClientNotRegistered = 0x000019ED,

        /// <summary>
        /// Log service encountered an error when attempting to read from a log container.
        /// </summary>
        LogContainerReadFailed = 0x000019EF,

        /// <summary>
        /// Log service encountered an error when attempting open a log container.
        /// </summary>
        LogContainerOpenFailed = 0x000019F1,

        /// <summary>
        /// Log service is not in the correct state to perform a requested action.
        /// </summary>
        LogStateInvalid = 0x000019F3,

        /// <summary>
        /// Log space cannot be reclaimed because the log is pinned.
        /// </summary>
        LogPinned = 0x000019F4,

        /// <summary>
        /// Log metadata flush failed.
        /// </summary>
        LogMetadataFlushFailed = 0x000019F5,

        /// <summary>
        /// Security on the log and its containers is inconsistent.
        /// </summary>
        LogInconsistentSecurity = 0x000019F6,

        /// <summary>
        /// Records were appended to the log or reservation changes were made, but the log could not be flushed.
        /// </summary>
        LogAppendedFlushFailed = 0x000019F7,

        /// <summary>
        /// The log is pinned due to reservation consuming most of the log space. Free some reserved records to make space available.
        /// </summary>
        LogPinnedReservation = 0x000019F8,

        /// <summary>
        /// The transaction handle associated with this operation is not valid.
        /// </summary>
        InvalidTransaction = 0x00001A2C,

        /// <summary>
        /// The requested operation was made in the context of a transaction that is no longer active.
        /// </summary>
        TransactionNotActive = 0x00001A2D,

        /// <summary>
        /// The caller has called a response API, but the response is not expected because the TM did not issue the corresponding request to the caller.
        /// </summary>
        TransactionNotRequested = 0x00001A2F,

        /// <summary>
        /// The Transaction Manager was unable to be successfully initialized. Transacted operations are not supported.
        /// </summary>
        TmInitializationFailed = 0x00001A32,

        /// <summary>
        /// The specified ResourceManager made no changes or updates to the resource under this transaction.
        /// </summary>
        ResourcemanagerReadOnly = 0x00001A33,

        /// <summary>
        /// The resource manager has attempted to prepare a transaction that it has not successfully joined.
        /// </summary>
        TransactionNotJoined = 0x00001A34,

        /// <summary>
        /// The requested propagation protocol was not registered as a CRM.
        /// </summary>
        CrmProtocolNotFound = 0x00001A38,

        /// <summary>
        /// The specified Transaction object could not be opened, because it was not found.
        /// </summary>
        TransactionNotFound = 0x00001A3B,

        /// <summary>
        /// The specified ResourceManager object could not be opened, because it was not found.
        /// </summary>
        ResourcemanagerNotFound = 0x00001A3C,

        /// <summary>
        /// The specified Enlistment object could not be opened, because it was not found.
        /// </summary>
        EnlistmentNotFound = 0x00001A3D,

        /// <summary>
        /// The call to create a superior Enlistment on this Transaction object could not be completed, because the Transaction object specified for the enlistment is a subordinate branch of the Transaction. Only the root of the Transaction can be enlisted on as a superior.
        /// </summary>
        TransactionNotRoot = 0x00001A41,

        /// <summary>
        /// The transaction does not have a superior enlistment.
        /// </summary>
        TransactionNoSuperior = 0x00001A4A,

        /// <summary>
        /// The attempt to commit the Transaction completed, but it is possible that some portion of the transaction tree did not commit successfully due to heuristics.  Therefore it is possible that some data modified in the transaction may not have committed, resulting in transactional inconsistency.  If possible, check the consistency of the associated data.
        /// </summary>
        HeuristicDamagePossible = 0x00001A4B,

        /// <summary>
        /// The function attempted to use a name that is reserved for use by another transaction.
        /// </summary>
        TransactionalConflict = 0x00001A90,

        /// <summary>
        /// Transaction support within the specified resource manager is not started or was shut down due to an error.
        /// </summary>
        RmNotActive = 0x00001A91,

        /// <summary>
        /// The metadata of the RM has been corrupted. The RM will not function.
        /// </summary>
        RmMetadataCorrupt = 0x00001A92,

        /// <summary>
        /// The specified directory does not contain a resource manager.
        /// </summary>
        DirectoryNotRm = 0x00001A93,

        /// <summary>
        /// The requested log size is invalid.
        /// </summary>
        LogResizeInvalidSize = 0x00001A96,

        /// <summary>
        /// The object (file, stream, link) corresponding to the handle has been deleted by a Transaction Savepoint Rollback.
        /// </summary>
        ObjectNoLongerExists = 0x00001A97,

        /// <summary>
        /// The handle has been invalidated by a transaction. The most likely cause is the presence of memory mapping on a file or an open handle when the transaction ended or rolled back to savepoint.
        /// </summary>
        HandleNoLongerValid = 0x00001A9F,

        /// <summary>
        /// There is no transaction metadata on the file.
        /// </summary>
        NoTxfMetadata = 0x00001AA0,

        /// <summary>
        /// The log data is corrupt.
        /// </summary>
        LogCorruptionDetected = 0x00001AA1,

        /// <summary>
        /// The transaction outcome is unavailable because the resource manager responsible for it has disconnected.
        /// </summary>
        RmDisconnected = 0x00001AA3,

        /// <summary>
        /// The request was rejected because the enlistment in question is not a superior enlistment.
        /// </summary>
        EnlistmentNotSuperior = 0x00001AA4,

        /// <summary>
        /// The transactional resource manager is already consistent. Recovery is not needed.
        /// </summary>
        RecoveryNotNeeded = 0x00001AA5,

        /// <summary>
        /// The transactional resource manager has already been started.
        /// </summary>
        RmAlreadyStarted = 0x00001AA6,

        /// <summary>
        /// The operation would involve a single file with two transactional resource managers and is therefore not allowed.
        /// </summary>
        CantCrossRmBoundary = 0x00001AA9,

        /// <summary>
        /// The $Txf directory must be empty for this operation to succeed.
        /// </summary>
        TxfDirNotEmpty = 0x00001AAA,

        /// <summary>
        /// The operation could not be completed because the transaction manager does not have a log.
        /// </summary>
        TmVolatile = 0x00001AAC,

        /// <summary>
        /// A rollback could not be scheduled because a previously scheduled rollback has already executed or been queued for execution.
        /// </summary>
        RollbackTimerExpired = 0x00001AAD,

        /// <summary>
        /// The transactional metadata attribute on the file or directory is corrupt and unreadable.
        /// </summary>
        TxfAttributeCorrupt = 0x00001AAE,

        /// <summary>
        /// An attempt to create space in the transactional resource manager's log failed. The failure status has been recorded in the event log.
        /// </summary>
        LogGrowthFailed = 0x00001AB1,

        /// <summary>
        /// The request to thaw frozen transactions was ignored because transactions had not previously been frozen.
        /// </summary>
        TransactionsNotFrozen = 0x00001AB7,

        /// <summary>
        /// The target volume is not a snapshot volume. This operation is only valid on a volume mounted as a snapshot.
        /// </summary>
        NotSnapshotVolume = 0x00001AB9,

        /// <summary>
        /// Windows has discovered corruption in a file, and that file has since been repaired. Data loss may have occurred.
        /// </summary>
        DataLostRepair = 0x00001ABB,

        /// <summary>
        /// The call to create a TransactionManager object failed because the Tm Identity stored in the logfile does not match the Tm Identity that was passed in as an argument.
        /// </summary>
        TmIdentityMismatch = 0x00001ABD,

        /// <summary>
        /// I/O was attempted on a section object that has been floated as a result of a transaction ending. There is no valid data.
        /// </summary>
        FloatedSection = 0x00001ABE,

        /// <summary>
        /// The transactional resource manager had too many tranactions outstanding that could not be aborted. The transactional resource manger has been shut down.
        /// </summary>
        CannotAbortTransactions = 0x00001AC0,

        /// <summary>
        /// The operation could not be completed due to bad clusters on disk.
        /// </summary>
        BadClusters = 0x00001AC1,

        /// <summary>
        /// The operation could not be completed because the volume is dirty. Please run chkdsk and try again.
        /// </summary>
        VolumeDirty = 0x00001AC3,

        /// <summary>
        /// The handle is no longer properly associated with its transaction.  It may have been opened in a transactional resource manager that was subsequently forced to restart.  Please close the handle and open a new one.
        /// </summary>
        ExpiredHandle = 0x00001AC6,

        /// <summary>
        /// The specified operation could not be performed because the resource manager is not enlisted in the transaction.
        /// </summary>
        TransactionNotEnlisted = 0x00001AC7,

        /// <summary>
        /// The specified protocol driver is invalid.
        /// </summary>
        CtxInvalidPd = 0x00001B5A,

        /// <summary>
        /// The specified protocol driver was not found in the system path.
        /// </summary>
        CtxPdNotFound = 0x00001B5B,

        /// <summary>
        /// The specified terminal connection driver was not found in the system path.
        /// </summary>
        CtxWdNotFound = 0x00001B5C,

        /// <summary>
        /// A close operation is pending on the session.
        /// </summary>
        CtxClosePending = 0x00001B5F,

        /// <summary>
        /// There are no free output buffers available.
        /// </summary>
        CtxNoOutbuf = 0x00001B60,

        /// <summary>
        /// The MODEM.INF file was not found.
        /// </summary>
        CtxModemInfNotFound = 0x00001B61,

        /// <summary>
        /// The modem name was not found in MODEM.INF.
        /// </summary>
        CtxInvalidModemname = 0x00001B62,

        /// <summary>
        /// The modem did not accept the command sent to it. Verify that the configured modem name matches the attached modem.
        /// </summary>
        CtxModemResponseError = 0x00001B63,

        /// <summary>
        /// Busy signal detected at remote site on callback.
        /// </summary>
        CtxModemResponseBusy = 0x00001B67,

        /// <summary>
        /// Voice detected at remote site on callback.
        /// </summary>
        CtxModemResponseVoice = 0x00001B68,

        /// <summary>
        /// Transport driver error
        /// </summary>
        CtxTdError = 0x00001B69,

        /// <summary>
        /// The specified session cannot be found.
        /// </summary>
        CtxWinstationNotFound = 0x00001B6E,

        /// <summary>
        /// The task you are trying to do can't be completed because Remote Desktop Services is currently busy. Please try again in a few minutes. Other users should still be able to log on.
        /// </summary>
        CtxWinstationBusy = 0x00001B70,

        /// <summary>
        /// An attempt has been made to connect to a session whose video mode is not supported by the current client.
        /// </summary>
        CtxBadVideoMode = 0x00001B71,

        /// <summary>
        /// The application attempted to enable DOS graphics mode. DOS graphics mode is not supported.
        /// </summary>
        CtxGraphicsInvalid = 0x00001B7B,

        /// <summary>
        /// Your interactive logon privilege has been disabled. Please contact your administrator.
        /// </summary>
        CtxLogonDisabled = 0x00001B7D,

        /// <summary>
        /// The requested operation can be performed only on the system console. This is most often the result of a driver or system DLL requiring direct console access.
        /// </summary>
        CtxNotConsole = 0x00001B7E,

        /// <summary>
        /// The client failed to respond to the server connect message.
        /// </summary>
        CtxClientQueryTimeout = 0x00001B80,

        /// <summary>
        /// Disconnecting the console session is not supported.
        /// </summary>
        CtxConsoleDisconnect = 0x00001B81,

        /// <summary>
        /// Reconnecting a disconnected session to the console is not supported.
        /// </summary>
        CtxConsoleConnect = 0x00001B82,

        /// <summary>
        /// The request to control another session remotely was denied.
        /// </summary>
        CtxShadowDenied = 0x00001B84,

        /// <summary>
        /// The specified terminal connection driver is invalid.
        /// </summary>
        CtxInvalidWd = 0x00001B89,

        /// <summary>
        /// The requested session cannot be controlled remotely.
        /// This may be because the session is disconnected or does not currently have a user logged on.
        /// </summary>
        CtxShadowInvalid = 0x00001B8A,

        /// <summary>
        /// The requested session is not configured to allow remote control.
        /// </summary>
        CtxShadowDisabled = 0x00001B8B,

        /// <summary>
        /// Your request to connect to this Terminal Server has been rejected. Your Terminal Server client license number is currently being used by another user. Please call your system administrator to obtain a unique license number.
        /// </summary>
        CtxClientLicenseInUse = 0x00001B8C,

        /// <summary>
        /// The number of connections to this computer is limited and all connections are in use right now. Try connecting later or contact your system administrator.
        /// </summary>
        CtxLicenseNotAvailable = 0x00001B8E,

        /// <summary>
        /// The system license has expired. Your logon request is denied.
        /// </summary>
        CtxLicenseExpired = 0x00001B90,

        /// <summary>
        /// Remote control could not be terminated because the specified session is not currently being remotely controlled.
        /// </summary>
        CtxShadowNotRunning = 0x00001B91,

        /// <summary>
        /// Activation has already been reset the maximum number of times for this installation. Your activation timer will not be cleared.
        /// </summary>
        ActivationCountExceeded = 0x00001B93,

        /// <summary>
        /// Remote logins are currently disabled.
        /// </summary>
        CtxWinstationsDisabled = 0x00001B94,

        /// <summary>
        /// The user %s\\%s is currently logged on to this computer. Only the current user or an administrator can log on to this computer.
        /// </summary>
        CtxSessionInUse = 0x00001B96,

        /// <summary>
        /// The user %s\\%s is already logged on to the console of this computer. You do not have permission to log in at this time. To resolve this issue, contact %s\\%s and have them log off.
        /// </summary>
        CtxNoForceLogoff = 0x00001B97,

        /// <summary>
        /// Unable to log you on because of an account restriction.
        /// </summary>
        CtxAccountRestriction = 0x00001B98,

        /// <summary>
        /// The RDP protocol component %2 detected an error in the protocol stream and has disconnected the client.
        /// </summary>
        RdpProtocolError = 0x00001B99,

        /// <summary>
        /// The Client Drive Mapping Service Has Connected on Terminal Connection.
        /// </summary>
        CtxCdmConnect = 0x00001B9A,

        /// <summary>
        /// The Client Drive Mapping Service Has Disconnected on Terminal Connection.
        /// </summary>
        CtxCdmDisconnect = 0x00001B9B,

        /// <summary>
        /// The Terminal Server security layer detected an error in the protocol stream and has disconnected the client.
        /// </summary>
        CtxSecurityLayerError = 0x00001B9C,

        /// <summary>
        /// The target session is incompatible with the current session.
        /// </summary>
        TsIncompatibleSessions = 0x00001B9D,

        /// <summary>
        /// Windows can't connect to your session because a problem occurred in the Windows video subsystem. Try connecting again later, or contact the server administrator for assistance.
        /// </summary>
        TsVideoSubsystemError = 0x00001B9E,

        /// <summary>
        /// The file replication service API was called incorrectly.
        /// </summary>
        FrsErrInvalidApiSequence = 0x00001F41,

        /// <summary>
        /// The file replication service cannot be started.
        /// </summary>
        FrsErrStartingService = 0x00001F42,

        /// <summary>
        /// The file replication service cannot be stopped.
        /// </summary>
        FrsErrStoppingService = 0x00001F43,

        /// <summary>
        /// The file replication service API terminated the request. The event log may have more information.
        /// </summary>
        FrsErrInternalApi = 0x00001F44,

        /// <summary>
        /// The file replication service terminated the request. The event log may have more information.
        /// </summary>
        FrsErrInternal = 0x00001F45,

        /// <summary>
        /// The file replication service cannot be contacted. The event log may have more information.
        /// </summary>
        FrsErrServiceComm = 0x00001F46,

        /// <summary>
        /// The file replication service cannot satisfy the request because the user has insufficient privileges. The event log may have more information.
        /// </summary>
        FrsErrInsufficientPriv = 0x00001F47,

        /// <summary>
        /// The file replication service cannot satisfy the request because authenticated RPC is not available. The event log may have more information.
        /// </summary>
        FrsErrAuthentication = 0x00001F48,

        /// <summary>
        /// The file replication service cannot satisfy the request because authenticated RPC is not available on the domain controller. The event log may have more information.
        /// </summary>
        FrsErrParentAuthentication = 0x00001F4A,

        /// <summary>
        /// The file replication service cannot communicate with the file replication service on the domain controller. The event log may have more information.
        /// </summary>
        FrsErrChildToParentComm = 0x00001F4B,

        /// <summary>
        /// The file replication service on the domain controller cannot communicate with the file replication service on this computer. The event log may have more information.
        /// </summary>
        FrsErrParentToChildComm = 0x00001F4C,

        /// <summary>
        /// The file replication service cannot populate the system volume because of an internal error. The event log may have more information.
        /// </summary>
        FrsErrSysvolPopulate = 0x00001F4D,

        /// <summary>
        /// The file replication service cannot populate the system volume because of an internal timeout. The event log may have more information.
        /// </summary>
        FrsErrSysvolPopulateTimeout = 0x00001F4E,

        /// <summary>
        /// The file replication service cannot process the request. The system volume is busy with a previous request.
        /// </summary>
        FrsErrSysvolIsBusy = 0x00001F4F,

        /// <summary>
        /// The file replication service cannot stop replicating the system volume because of an internal error. The event log may have more information.
        /// </summary>
        FrsErrSysvolDemote = 0x00001F50,

        /// <summary>
        /// An error occurred while installing the directory service. For more information, see the event log.
        /// </summary>
        DsNotInstalled = 0x00002008,

        /// <summary>
        /// The specified directory service attribute or value does not exist.
        /// </summary>
        DsNoAttributeOrValue = 0x0000200A,

        /// <summary>
        /// The directory service is busy.
        /// </summary>
        DsBusy = 0x0000200E,

        /// <summary>
        /// The directory service is unavailable.
        /// </summary>
        DsUnavailable = 0x0000200F,

        /// <summary>
        /// The directory service was unable to allocate a relative identifier.
        /// </summary>
        DsNoRidsAllocated = 0x00002010,

        /// <summary>
        /// The directory service has exhausted the pool of relative identifiers.
        /// </summary>
        DsNoMoreRids = 0x00002011,

        /// <summary>
        /// The requested operation could not be performed because the directory service is not the master for that type of operation.
        /// </summary>
        DsIncorrectRoleOwner = 0x00002012,

        /// <summary>
        /// The directory service was unable to initialize the subsystem that allocates relative identifiers.
        /// </summary>
        DsRidmgrInitError = 0x00002013,

        /// <summary>
        /// The requested operation did not satisfy one or more constraints associated with the class of the object.
        /// </summary>
        DsObjClassViolation = 0x00002014,

        /// <summary>
        /// The directory service can perform the requested operation only on a leaf object.
        /// </summary>
        DsCantOnNonLeaf = 0x00002015,

        /// <summary>
        /// The directory service cannot perform the requested operation on the RDN attribute of an object.
        /// </summary>
        DsCantOnRdn = 0x00002016,

        /// <summary>
        /// The directory service detected an attempt to modify the object class of an object.
        /// </summary>
        DsCantModObjClass = 0x00002017,

        /// <summary>
        /// The requested cross-domain move operation could not be performed.
        /// </summary>
        DsCrossDomMoveError = 0x00002018,

        /// <summary>
        /// Unable to contact the global catalog server.
        /// </summary>
        DsGcNotAvailable = 0x00002019,

        /// <summary>
        /// The policy object is shared and can only be modified at the root.
        /// </summary>
        SharedPolicy = 0x0000201A,

        /// <summary>
        /// The policy object does not exist.
        /// </summary>
        PolicyObjectNotFound = 0x0000201B,

        /// <summary>
        /// The requested policy information is only in the directory service.
        /// </summary>
        PolicyOnlyInDs = 0x0000201C,

        /// <summary>
        /// A domain controller promotion is currently active.
        /// </summary>
        PromotionActive = 0x0000201D,

        /// <summary>
        /// A domain controller promotion is not currently active
        /// </summary>
        NoPromotionActive = 0x0000201E,

        /// <summary>
        /// An operations error occurred.
        /// </summary>
        DsOperationsError = 0x00002020,

        /// <summary>
        /// A protocol error occurred.
        /// </summary>
        DsProtocolError = 0x00002021,

        /// <summary>
        /// The time limit for this request was exceeded.
        /// </summary>
        DsTimelimitExceeded = 0x00002022,

        /// <summary>
        /// The size limit for this request was exceeded.
        /// </summary>
        DsSizelimitExceeded = 0x00002023,

        /// <summary>
        /// The administrative limit for this request was exceeded.
        /// </summary>
        DsAdminLimitExceeded = 0x00002024,

        /// <summary>
        /// The compare response was false.
        /// </summary>
        DsCompareFalse = 0x00002025,

        /// <summary>
        /// The compare response was true.
        /// </summary>
        DsCompareTrue = 0x00002026,

        /// <summary>
        /// A more secure authentication method is required for this server.
        /// </summary>
        DsStrongAuthRequired = 0x00002028,

        /// <summary>
        /// Inappropriate authentication.
        /// </summary>
        DsInappropriateAuth = 0x00002029,

        /// <summary>
        /// The authentication mechanism is unknown.
        /// </summary>
        DsAuthUnknown = 0x0000202A,

        /// <summary>
        /// A referral was returned from the server.
        /// </summary>
        DsReferral = 0x0000202B,

        /// <summary>
        /// Inappropriate matching.
        /// </summary>
        DsInappropriateMatching = 0x0000202E,

        /// <summary>
        /// A constraint violation occurred.
        /// </summary>
        DsConstraintViolation = 0x0000202F,

        /// <summary>
        /// There is no such object on the server.
        /// </summary>
        DsNoSuchObject = 0x00002030,

        /// <summary>
        /// There is an alias problem.
        /// </summary>
        DsAliasProblem = 0x00002031,

        /// <summary>
        /// An invalid dn syntax has been specified.
        /// </summary>
        DsInvalidDnSyntax = 0x00002032,

        /// <summary>
        /// The object is a leaf object.
        /// </summary>
        DsIsLeaf = 0x00002033,

        /// <summary>
        /// There is an alias dereferencing problem.
        /// </summary>
        DsAliasDerefProblem = 0x00002034,

        /// <summary>
        /// The server is unwilling to process the request.
        /// </summary>
        DsUnwillingToPerform = 0x00002035,

        /// <summary>
        /// A loop has been detected.
        /// </summary>
        DsLoopDetect = 0x00002036,

        /// <summary>
        /// There is a naming violation.
        /// </summary>
        DsNamingViolation = 0x00002037,

        /// <summary>
        /// The operation affects multiple DSAs
        /// </summary>
        DsAffectsMultipleDsas = 0x00002039,

        /// <summary>
        /// The server is not operational.
        /// </summary>
        DsServerDown = 0x0000203A,

        /// <summary>
        /// A local error has occurred.
        /// </summary>
        DsLocalError = 0x0000203B,

        /// <summary>
        /// An encoding error has occurred.
        /// </summary>
        DsEncodingError = 0x0000203C,

        /// <summary>
        /// A decoding error has occurred.
        /// </summary>
        DsDecodingError = 0x0000203D,

        /// <summary>
        /// The search filter cannot be recognized.
        /// </summary>
        DsFilterUnknown = 0x0000203E,

        /// <summary>
        /// One or more parameters are illegal.
        /// </summary>
        DsParamError = 0x0000203F,

        /// <summary>
        /// The specified method is not supported.
        /// </summary>
        DsNotSupported = 0x00002040,

        /// <summary>
        /// No results were returned.
        /// </summary>
        DsNoResultsReturned = 0x00002041,

        /// <summary>
        /// The specified control is not supported by the server.
        /// </summary>
        DsControlNotFound = 0x00002042,

        /// <summary>
        /// A referral loop was detected by the client.
        /// </summary>
        DsClientLoop = 0x00002043,

        /// <summary>
        /// The search requires a SORT control.
        /// </summary>
        DsSortControlMissing = 0x00002045,

        /// <summary>
        /// The search results exceed the offset range specified.
        /// </summary>
        DsOffsetRangeError = 0x00002046,

        /// <summary>
        /// The directory service detected the subsystem that allocates relative identifiers is disabled. This can occur as a protective mechanism when the system determines a significant portion of relative identifiers (RIDs) have been exhausted. Please see http://go.microsoft.com/fwlink/?LinkId=228610 for recommended diagnostic steps and the procedure to re-enable account creation.
        /// </summary>
        DsRidmgrDisabled = 0x00002047,

        /// <summary>
        /// The root object must be the head of a naming context. The root object cannot have an instantiated parent.
        /// </summary>
        DsRootMustBeNc = 0x0000206D,

        /// <summary>
        /// The add replica operation cannot be performed. The naming context must be writeable in order to create the replica.
        /// </summary>
        DsAddReplicaInhibited = 0x0000206E,

        /// <summary>
        /// A reference to an attribute that is not defined in the schema occurred.
        /// </summary>
        DsAttNotDefInSchema = 0x0000206F,

        /// <summary>
        /// The maximum size of an object has been exceeded.
        /// </summary>
        DsMaxObjSizeExceeded = 0x00002070,

        /// <summary>
        /// An attempt was made to add an object to the directory with a name that is already in use.
        /// </summary>
        DsObjStringNameExists = 0x00002071,

        /// <summary>
        /// The user buffer is too small.
        /// </summary>
        DsUserBufferToSmall = 0x00002075,

        /// <summary>
        /// The attribute specified in the operation is not present on the object.
        /// </summary>
        DsAttIsNotOnObj = 0x00002076,

        /// <summary>
        /// Illegal modify operation. Some aspect of the modification is not permitted.
        /// </summary>
        DsIllegalModOperation = 0x00002077,

        /// <summary>
        /// The specified object is too large.
        /// </summary>
        DsObjTooLarge = 0x00002078,

        /// <summary>
        /// The specified instance type is not valid.
        /// </summary>
        DsBadInstanceType = 0x00002079,

        /// <summary>
        /// The operation must be performed at a master DSA.
        /// </summary>
        DsMasterdsaRequired = 0x0000207A,

        /// <summary>
        /// The object class attribute must be specified.
        /// </summary>
        DsObjectClassRequired = 0x0000207B,

        /// <summary>
        /// A required attribute is missing.
        /// </summary>
        DsMissingRequiredAtt = 0x0000207C,

        /// <summary>
        /// An attempt was made to modify an object to include an attribute that is not legal for its class.
        /// </summary>
        DsAttNotDefForClass = 0x0000207D,

        /// <summary>
        /// The specified attribute is already present on the object.
        /// </summary>
        DsAttAlreadyExists = 0x0000207E,

        /// <summary>
        /// The specified attribute is not present, or has no values.
        /// </summary>
        DsCantAddAttValues = 0x00002080,

        /// <summary>
        /// A value for the attribute was not in the acceptable range of values.
        /// </summary>
        DsRangeConstraint = 0x00002082,

        /// <summary>
        /// The specified value already exists.
        /// </summary>
        DsAttValAlreadyExists = 0x00002083,

        /// <summary>
        /// The attribute cannot be removed because it is not present on the object.
        /// </summary>
        DsCantRemMissingAtt = 0x00002084,

        /// <summary>
        /// The specified root object cannot be a subref.
        /// </summary>
        DsRootCantBeSubref = 0x00002086,

        /// <summary>
        /// Chaining is not permitted.
        /// </summary>
        DsNoChaining = 0x00002087,

        /// <summary>
        /// Chained evaluation is not permitted.
        /// </summary>
        DsNoChainedEval = 0x00002088,

        /// <summary>
        /// The operation could not be performed because the object's parent is either uninstantiated or deleted.
        /// </summary>
        DsNoParentObject = 0x00002089,

        /// <summary>
        /// Having a parent that is an alias is not permitted. Aliases are leaf objects.
        /// </summary>
        DsParentIsAnAlias = 0x0000208A,

        /// <summary>
        /// The operation cannot be performed because child objects exist. This operation can only be performed on a leaf object.
        /// </summary>
        DsChildrenExist = 0x0000208C,

        /// <summary>
        /// Directory object not found.
        /// </summary>
        DsObjNotFound = 0x0000208D,

        /// <summary>
        /// The aliased object is missing.
        /// </summary>
        DsAliasedObjMissing = 0x0000208E,

        /// <summary>
        /// The object name has bad syntax.
        /// </summary>
        DsBadNameSyntax = 0x0000208F,

        /// <summary>
        /// It is not permitted for an alias to refer to another alias.
        /// </summary>
        DsAliasPointsToAlias = 0x00002090,

        /// <summary>
        /// The alias cannot be dereferenced.
        /// </summary>
        DsCantDerefAlias = 0x00002091,

        /// <summary>
        /// The operation is out of scope.
        /// </summary>
        DsOutOfScope = 0x00002092,

        /// <summary>
        /// The operation cannot continue because the object is in the process of being removed.
        /// </summary>
        DsObjectBeingRemoved = 0x00002093,

        /// <summary>
        /// The DSA object cannot be deleted.
        /// </summary>
        DsCantDeleteDsaObj = 0x00002094,

        /// <summary>
        /// A directory service error has occurred.
        /// </summary>
        DsGenericError = 0x00002095,

        /// <summary>
        /// The operation can only be performed on an internal master DSA object.
        /// </summary>
        DsDsaMustBeIntMaster = 0x00002096,

        /// <summary>
        /// The object must be of class DSA.
        /// </summary>
        DsClassNotDsa = 0x00002097,

        /// <summary>
        /// Insufficient access rights to perform the operation.
        /// </summary>
        DsInsuffAccessRights = 0x00002098,

        /// <summary>
        /// The object cannot be added because the parent is not on the list of possible superiors.
        /// </summary>
        DsIllegalSuperior = 0x00002099,

        /// <summary>
        /// Access to the attribute is not permitted because the attribute is owned by the Security Accounts Manager (SAM).
        /// </summary>
        DsAttributeOwnedBySam = 0x0000209A,

        /// <summary>
        /// The name has too many parts.
        /// </summary>
        DsNameTooManyParts = 0x0000209B,

        /// <summary>
        /// The name is too long.
        /// </summary>
        DsNameTooLong = 0x0000209C,

        /// <summary>
        /// The name value is too long.
        /// </summary>
        DsNameValueTooLong = 0x0000209D,

        /// <summary>
        /// The directory service encountered an error parsing a name.
        /// </summary>
        DsNameUnparseable = 0x0000209E,

        /// <summary>
        /// The directory service cannot get the attribute type for a name.
        /// </summary>
        DsNameTypeUnknown = 0x0000209F,

        /// <summary>
        /// The name does not identify an object; the name identifies a phantom.
        /// </summary>
        DsNotAnObject = 0x000020A0,

        /// <summary>
        /// The security descriptor is too short.
        /// </summary>
        DsSecDescTooShort = 0x000020A1,

        /// <summary>
        /// The security descriptor is invalid.
        /// </summary>
        DsSecDescInvalid = 0x000020A2,

        /// <summary>
        /// Failed to create name for deleted object.
        /// </summary>
        DsNoDeletedName = 0x000020A3,

        /// <summary>
        /// The object must be a naming context.
        /// </summary>
        DsNcnameMustBeNc = 0x000020A5,

        /// <summary>
        /// It is not permitted to add an attribute which is owned by the system.
        /// </summary>
        DsCantAddSystemOnly = 0x000020A6,

        /// <summary>
        /// The class of the object must be structural; you cannot instantiate an abstract class.
        /// </summary>
        DsClassMustBeConcrete = 0x000020A7,

        /// <summary>
        /// The schema object could not be found.
        /// </summary>
        DsInvalidDmd = 0x000020A8,

        /// <summary>
        /// A local object with this GUID (dead or alive) already exists.
        /// </summary>
        DsObjGuidExists = 0x000020A9,

        /// <summary>
        /// The operation cannot be performed on a back link.
        /// </summary>
        DsNotOnBacklink = 0x000020AA,

        /// <summary>
        /// The cross reference for the specified naming context could not be found.
        /// </summary>
        DsNoCrossrefForNc = 0x000020AB,

        /// <summary>
        /// The operation could not be performed because the directory service is shutting down.
        /// </summary>
        DsShuttingDown = 0x000020AC,

        /// <summary>
        /// The directory service request is invalid.
        /// </summary>
        DsUnknownOperation = 0x000020AD,

        /// <summary>
        /// The role owner attribute could not be read.
        /// </summary>
        DsInvalidRoleOwner = 0x000020AE,

        /// <summary>
        /// The requested FSMO operation failed. The current FSMO holder could not be contacted.
        /// </summary>
        DsCouldntContactFsmo = 0x000020AF,

        /// <summary>
        /// Modification of a DN across a naming context is not permitted.
        /// </summary>
        DsCrossNcDnRename = 0x000020B0,

        /// <summary>
        /// The attribute cannot be modified because it is owned by the system.
        /// </summary>
        DsCantModSystemOnly = 0x000020B1,

        /// <summary>
        /// Only the replicator can perform this function.
        /// </summary>
        DsReplicatorOnly = 0x000020B2,

        /// <summary>
        /// The specified class is not defined.
        /// </summary>
        DsObjClassNotDefined = 0x000020B3,

        /// <summary>
        /// The specified class is not a subclass.
        /// </summary>
        DsObjClassNotSubclass = 0x000020B4,

        /// <summary>
        /// The name reference is invalid.
        /// </summary>
        DsNameReferenceInvalid = 0x000020B5,

        /// <summary>
        /// A cross reference already exists.
        /// </summary>
        DsCrossRefExists = 0x000020B6,

        /// <summary>
        /// Schema update failed: duplicate RDN.
        /// </summary>
        DsDupRdn = 0x000020BA,

        /// <summary>
        /// Schema update failed: duplicate OID.
        /// </summary>
        DsDupOid = 0x000020BB,

        /// <summary>
        /// Schema update failed: duplicate MAPI identifier.
        /// </summary>
        DsDupMapiId = 0x000020BC,

        /// <summary>
        /// Schema update failed: duplicate schema-id GUID.
        /// </summary>
        DsDupSchemaIdGuid = 0x000020BD,

        /// <summary>
        /// Schema update failed: duplicate LDAP display name.
        /// </summary>
        DsDupLdapDisplayName = 0x000020BE,

        /// <summary>
        /// Schema update failed: range-lower less than range upper.    /// </summary>
        DsSemanticAttTest = 0x000020BF,

        /// <summary>
        /// Schema update failed: syntax mismatch.
        /// </summary>
        DsSyntaxMismatch = 0x000020C0,

        /// <summary>
        /// Schema deletion failed: attribute is used in must-contain.
        /// </summary>
        DsExistsInMustHave = 0x000020C1,

        /// <summary>
        /// Schema deletion failed: attribute is used in may-contain.
        /// </summary>
        DsExistsInMayHave = 0x000020C2,

        /// <summary>
        /// Schema update failed: attribute in may-contain does not exist.
        /// </summary>
        DsNonexistentMayHave = 0x000020C3,

        /// <summary>
        /// Schema update failed: attribute in must-contain does not exist.
        /// </summary>
        DsNonexistentMustHave = 0x000020C4,

        /// <summary>
        /// Schema update failed: class in aux-class list does not exist or is not an auxiliary class.
        /// </summary>
        DsAuxClsTestFail = 0x000020C5,

        /// <summary>
        /// Schema update failed: class in poss-superiors does not exist.
        /// </summary>
        DsNonexistentPossSup = 0x000020C6,

        /// <summary>
        /// Schema update failed: class in subclassof list does not exist or does not satisfy hierarchy rules.
        /// </summary>
        DsSubClsTestFail = 0x000020C7,

        /// <summary>
        /// Schema update failed: Rdn-Att-Id has wrong syntax.
        /// </summary>
        DsBadRdnAttIdSyntax = 0x000020C8,

        /// <summary>
        /// Schema deletion failed: class is used as auxiliary class.
        /// </summary>
        DsExistsInAuxCls = 0x000020C9,

        /// <summary>
        /// Schema deletion failed: class is used as sub class.
        /// </summary>
        DsExistsInSubCls = 0x000020CA,

        /// <summary>
        /// Schema deletion failed: class is used as poss superior.
        /// </summary>
        DsExistsInPossSup = 0x000020CB,

        /// <summary>
        /// Schema update failed in recalculating validation cache.
        /// </summary>
        DsRecalcschemaFailed = 0x000020CC,

        /// <summary>
        /// The requested delete operation could not be performed.
        /// </summary>
        DsCantDelete = 0x000020CE,

        /// <summary>
        /// Cannot read the governs class identifier for the schema record.
        /// </summary>
        DsAttSchemaReqId = 0x000020CF,

        /// <summary>
        /// The attribute schema has bad syntax.
        /// </summary>
        DsBadAttSchemaSyntax = 0x000020D0,

        /// <summary>
        /// The attribute could not be cached.
        /// </summary>
        DsCantCacheAtt = 0x000020D1,

        /// <summary>
        /// The class could not be cached.
        /// </summary>
        DsCantCacheClass = 0x000020D2,

        /// <summary>
        /// The attribute could not be removed from the cache.
        /// </summary>
        DsCantRemoveAttCache = 0x000020D3,

        /// <summary>
        /// The distinguished name attribute could not be read.
        /// </summary>
        DsCantRetrieveDn = 0x000020D5,

        /// <summary>
        /// No superior reference has been configured for the directory service. The directory service is therefore unable to issue referrals to objects outside this forest.
        /// </summary>
        DsMissingSupref = 0x000020D6,

        /// <summary>
        /// The instance type attribute could not be retrieved.
        /// </summary>
        DsCantRetrieveInstance = 0x000020D7,

        /// <summary>
        /// An internal error has occurred.
        /// </summary>
        DsCodeInconsistency = 0x000020D8,

        /// <summary>
        /// A database error has occurred.
        /// </summary>
        DsDatabaseError = 0x000020D9,

        /// <summary>
        /// The attribute GOVERNSID is missing.
        /// </summary>
        DsGovernsidMissing = 0x000020DA,

        /// <summary>
        /// An expected attribute is missing.
        /// </summary>
        DsMissingExpectedAtt = 0x000020DB,

        /// <summary>
        /// The specified naming context is missing a cross reference.
        /// </summary>
        DsNcnameMissingCrRef = 0x000020DC,

        /// <summary>
        /// The schema is not loaded.
        /// </summary>
        DsSchemaNotLoaded = 0x000020DE,

        /// <summary>
        /// Schema allocation failed. Please check if the machine is running low on memory.
        /// </summary>
        DsSchemaAllocFailed = 0x000020DF,

        /// <summary>
        /// Failed to obtain the required syntax for the attribute schema.
        /// </summary>
        DsAttSchemaReqSyntax = 0x000020E0,

        /// <summary>
        /// The global catalog verification failed. The global catalog is not available or does not support the operation. Some part of the directory is currently not available.
        /// </summary>
        DsGcverifyError = 0x000020E1,

        /// <summary>
        /// The replication operation failed because of a schema mismatch between the servers involved.
        /// </summary>
        DsDraSchemaMismatch = 0x000020E2,

        /// <summary>
        /// The DSA object could not be found.
        /// </summary>
        DsCantFindDsaObj = 0x000020E3,

        /// <summary>
        /// The naming context could not be found.
        /// </summary>
        DsCantFindExpectedNc = 0x000020E4,

        /// <summary>
        /// The naming context could not be found in the cache.
        /// </summary>
        DsCantFindNcInCache = 0x000020E5,

        /// <summary>
        /// The child object could not be retrieved.
        /// </summary>
        DsCantRetrieveChild = 0x000020E6,

        /// <summary>
        /// The hierarchy file is invalid.
        /// </summary>
        DsBadHierarchyFile = 0x000020E9,

        /// <summary>
        /// The directory configuration parameter is missing from the registry.
        /// </summary>
        DsConfigParamMissing = 0x000020EB,

        /// <summary>
        /// The directory service encountered an internal failure.
        /// </summary>
        DsInternalFailure = 0x000020EE,

        /// <summary>
        /// The directory service encountered an unknown failure.
        /// </summary>
        DsUnknownError = 0x000020EF,

        /// <summary>
        /// This directory server is shutting down, and cannot take ownership of new floating single-master operation roles.
        /// </summary>
        DsRefusingFsmoRoles = 0x000020F1,

        /// <summary>
        /// The directory service is missing mandatory configuration information, and is unable to determine the ownership of floating single-master operation roles.
        /// </summary>
        DsMissingFsmoSettings = 0x000020F2,

        /// <summary>
        /// The replication operation failed.
        /// </summary>
        DsDraGeneric = 0x000020F4,

        /// <summary>
        /// An invalid parameter was specified for this replication operation.
        /// </summary>
        DsDraInvalidParameter = 0x000020F5,

        /// <summary>
        /// The directory service is too busy to complete the replication operation at this time.
        /// </summary>
        DsDraBusy = 0x000020F6,

        /// <summary>
        /// The distinguished name specified for this replication operation is invalid.
        /// </summary>
        DsDraBadDn = 0x000020F7,

        /// <summary>
        /// The naming context specified for this replication operation is invalid.
        /// </summary>
        DsDraBadNc = 0x000020F8,

        /// <summary>
        /// The distinguished name specified for this replication operation already exists.
        /// </summary>
        DsDraDnExists = 0x000020F9,

        /// <summary>
        /// The replication system encountered an internal error.
        /// </summary>
        DsDraInternalError = 0x000020FA,

        /// <summary>
        /// The replication operation encountered a database inconsistency.
        /// </summary>
        DsDraInconsistentDit = 0x000020FB,

        /// <summary>
        /// The server specified for this replication operation could not be contacted.
        /// </summary>
        DsDraConnectionFailed = 0x000020FC,

        /// <summary>
        /// The replication operation encountered an object with an invalid instance type.
        /// </summary>
        DsDraBadInstanceType = 0x000020FD,

        /// <summary>
        /// The replication operation failed to allocate memory.
        /// </summary>
        DsDraOutOfMem = 0x000020FE,

        /// <summary>
        /// The replication operation encountered an error with the mail system.
        /// </summary>
        DsDraMailProblem = 0x000020FF,

        /// <summary>
        /// The replication reference information for the target server already exists.
        /// </summary>
        DsDraRefAlreadyExists = 0x00002100,

        /// <summary>
        /// The replication reference information for the target server does not exist.
        /// </summary>
        DsDraRefNotFound = 0x00002101,

        /// <summary>
        /// The naming context cannot be removed because it is replicated to another server.
        /// </summary>
        DsDraObjIsRepSource = 0x00002102,

        /// <summary>
        /// The replication operation encountered a database error.
        /// </summary>
        DsDraDbError = 0x00002103,

        /// <summary>
        /// The naming context is in the process of being removed or is not replicated from the specified server.
        /// </summary>
        DsDraNoReplica = 0x00002104,

        /// <summary>
        /// Replication access was denied.
        /// </summary>
        DsDraAccessDenied = 0x00002105,

        /// <summary>
        /// The requested operation is not supported by this version of the directory service.
        /// </summary>
        DsDraNotSupported = 0x00002106,

        /// <summary>
        /// The replication remote procedure call was cancelled.
        /// </summary>
        DsDraRpcCancelled = 0x00002107,

        /// <summary>
        /// The source server is currently rejecting replication requests.
        /// </summary>
        DsDraSourceDisabled = 0x00002108,

        /// <summary>
        /// The destination server is currently rejecting replication requests.
        /// </summary>
        DsDraSinkDisabled = 0x00002109,

        /// <summary>
        /// The replication operation failed due to a collision of object names.
        /// </summary>
        DsDraNameCollision = 0x0000210A,

        /// <summary>
        /// The replication source has been reinstalled.
        /// </summary>
        DsDraSourceReinstalled = 0x0000210B,

        /// <summary>
        /// The replication operation failed because a required parent object is missing.
        /// </summary>
        DsDraMissingParent = 0x0000210C,

        /// <summary>
        /// The replication operation was preempted.
        /// </summary>
        DsDraPreempted = 0x0000210D,

        /// <summary>
        /// The replication synchronization attempt was abandoned because of a lack of updates.
        /// </summary>
        DsDraAbandonSync = 0x0000210E,

        /// <summary>
        /// The replication operation was terminated because the system is shutting down.
        /// </summary>
        DsDraShutdown = 0x0000210F,

        /// <summary>
        /// Schema update failed: An attribute with the same link identifier already exists.
        /// </summary>
        DsDupLinkId = 0x00002114,

        /// <summary>
        /// Name translation: Generic processing error.
        /// </summary>
        DsNameErrorResolving = 0x00002115,

        /// <summary>
        /// Name translation: Could not find the name or insufficient right to see name.
        /// </summary>
        DsNameErrorNotFound = 0x00002116,

        /// <summary>
        /// Name translation: Input name mapped to more than one output name.
        /// </summary>
        DsNameErrorNotUnique = 0x00002117,

        /// <summary>
        /// Name translation: Input name found, but not the associated output format.
        /// </summary>
        DsNameErrorNoMapping = 0x00002118,

        /// <summary>
        /// Name translation: Unable to resolve completely, only the domain was found.
        /// </summary>
        DsNameErrorDomainOnly = 0x00002119,

        /// <summary>
        /// Modification of a constructed attribute is not allowed.
        /// </summary>
        DsConstructedAttMod = 0x0000211B,

        /// <summary>
        /// The OM-Object-Class specified is incorrect for an attribute with the specified syntax.
        /// </summary>
        DsWrongOmObjClass = 0x0000211C,

        /// <summary>
        /// The replication request has been posted; waiting for reply.
        /// </summary>
        DsDraReplPending = 0x0000211D,

        /// <summary>
        /// The requested operation requires a directory service, and none was available.
        /// </summary>
        DsDsRequired = 0x0000211E,

        /// <summary>
        /// The requested search operation is only supported for base searches.
        /// </summary>
        DsNonBaseSearch = 0x00002120,

        /// <summary>
        /// The search failed to retrieve attributes from the database.
        /// </summary>
        DsCantRetrieveAtts = 0x00002121,

        /// <summary>
        /// The schema update operation tried to add a backward link attribute that has no corresponding forward link.
        /// </summary>
        DsBacklinkWithoutLink = 0x00002122,

        /// <summary>
        /// Source and destination of a cross-domain move do not agree on the object's epoch number. Either source or destination does not have the latest version of the object.
        /// </summary>
        DsEpochMismatch = 0x00002123,

        /// <summary>
        /// Source and destination of a cross-domain move do not agree on the object's current name. Either source or destination does not have the latest version of the object.
        /// </summary>
        DsSrcNameMismatch = 0x00002124,

        /// <summary>
        /// Source and destination for a cross-domain move are not in agreement on the naming contexts in the forest. Either source or destination does not have the latest version of the Partitions container.
        /// </summary>
        DsDstNcMismatch = 0x00002126,

        /// <summary>
        /// Source and destination of a cross-domain move do not agree on the identity of the source object. Either source or destination does not have the latest version of the source object.
        /// </summary>
        DsSrcGuidMismatch = 0x00002128,

        /// <summary>
        /// A naming context head must be the immediate child of another naming context head, not of an interior node.
        /// </summary>
        DsNcMustHaveNcParent = 0x0000212E,

        /// <summary>
        /// Destination domain must be in native mode.
        /// </summary>
        DsDstDomainNotNative = 0x00002130,

        /// <summary>
        /// The search flags for the attribute are invalid. The ANR bit is valid only on attributes of Unicode or Teletex strings.
        /// </summary>
        DsInvalidSearchFlag = 0x00002134,

        /// <summary>
        /// Security Accounts Manager initialization failed because of the following error: %1.
        /// Error Status: 0x%2. Please shutdown this system and reboot into Directory Services Restore Mode, check the event log for more detailed information.
        /// </summary>
        DsSamInitFailure = 0x00002138,

        /// <summary>
        /// Adding a new mandatory attribute to an existing class, deleting a mandatory attribute from an existing class, or adding an optional attribute to the special class Top that is not a backlink attribute (directly or through inheritance, for example, by adding or deleting an auxiliary class) is not allowed.
        /// </summary>
        DsNonsafeSchemaChange = 0x0000213C,

        /// <summary>
        /// The specified group type is invalid.
        /// </summary>
        DsInvalidGroupType = 0x00002141,

        /// <summary>
        /// A group with primary members cannot change to a security-disabled group.
        /// </summary>
        DsHavePrimaryMembers = 0x00002149,

        /// <summary>
        /// Only DSAs configured to be Global Catalog servers should be allowed to hold the Domain Naming Master FSMO role. (Applies only to Windows 2000 servers)
        /// </summary>
        DsNamingMasterGc = 0x0000214B,

        /// <summary>
        /// The DSA operation is unable to proceed because of a DNS lookup failure.
        /// </summary>
        DsDnsLookupFailure = 0x0000214C,

        /// <summary>
        /// While processing a change to the DNS Host Name for an object, the Service Principal Name values could not be kept in sync.
        /// </summary>
        DsCouldntUpdateSpns = 0x0000214D,

        /// <summary>
        /// The Security Descriptor attribute could not be read.
        /// </summary>
        DsCantRetrieveSd = 0x0000214E,

        /// <summary>
        /// The object requested was not found, but an object with that key was found.
        /// </summary>
        DsKeyNotUnique = 0x0000214F,

        /// <summary>
        /// Directory Service cannot start.
        /// </summary>
        DsCantStart = 0x00002153,

        /// <summary>
        /// Directory Services could not start.
        /// </summary>
        DsInitFailure = 0x00002154,

        /// <summary>
        /// Security Accounts Manager initialization failed because of the following error: %1.
        /// Error Status: 0x%2. Click OK to shut down the system and reboot into Safe Mode. Check the event log for detailed information.
        /// </summary>
        SamInitFailure = 0x0000215D,

        /// <summary>
        /// Schema information could not be included in the replication request.
        /// </summary>
        DsDraSchemaInfoShip = 0x0000215E,

        /// <summary>
        /// The replication operation could not be completed due to a schema incompatibility.
        /// </summary>
        DsDraSchemaConflict = 0x0000215F,

        /// <summary>
        /// The replication update could not be applied because either the source or the destination has not yet received information regarding a recent cross-domain move operation.
        /// </summary>
        DsDraObjNcMismatch = 0x00002161,

        /// <summary>
        /// The requested domain could not be deleted because there exist domain controllers that still host this domain.
        /// </summary>
        DsNcStillHasDsas = 0x00002162,

        /// <summary>
        /// The requested operation can be performed only on a global catalog server.
        /// </summary>
        DsGcRequired = 0x00002163,

        /// <summary>
        /// The attribute is not allowed to be replicated to the GC because of security reasons.
        /// </summary>
        DsCantAddToGc = 0x00002166,

        /// <summary>
        /// The checkpoint with the PDC could not be taken because there too many modifications being processed currently.
        /// </summary>
        DsNoCheckpointWithPdc = 0x00002167,

        /// <summary>
        /// A Service Principal Name (SPN) could not be constructed because the provided hostname is not in the necessary format.
        /// </summary>
        DsInvalidNameForSpn = 0x0000216A,

        /// <summary>
        /// For security reasons, the operation must be run on the destination DC.
        /// </summary>
        DsMustBeRunOnDstDc = 0x0000216E,

        /// <summary>
        /// Directory Services could not start because of the following error: %1.
        /// Error Status: 0x%2. Please click OK to shutdown the system. You can use the recovery console to diagnose the system further.
        /// </summary>
        DsInitFailureConsole = 0x00002171,

        /// <summary>
        /// The version of the operating system installed on this server no longer supports the current AD DS Forest functional level or AD LDS Configuration Set functional level. You must raise the AD DS Forest functional level or AD LDS Configuration Set functional level before this server can become an AD DS Domain Controller or an AD LDS Instance in this Forest or Configuration Set.
        /// </summary>
        DsForestVersionTooLow = 0x00002175,

        /// <summary>
        /// The version of the operating system installed on this server no longer supports the current domain functional level. You must raise the domain functional level before this server can become a domain controller in this domain.
        /// </summary>
        DsDomainVersionTooLow = 0x00002176,

        /// <summary>
        /// The version of the operating system installed on this server is incompatible with the functional level of the domain or forest.
        /// </summary>
        DsIncompatibleVersion = 0x00002177,

        /// <summary>
        /// The functional level of the domain (or forest) cannot be raised to the requested value, because there exist one or more domain controllers in the domain (or forest) that are at a lower incompatible functional level.
        /// </summary>
        DsLowDsaVersion = 0x00002178,

        /// <summary>
        /// The requested name already exists as a unique identifier.
        /// </summary>
        DsNameNotUnique = 0x0000217B,

        /// <summary>
        /// The database is out of version store.
        /// </summary>
        DsOutOfVersionStore = 0x0000217D,

        /// <summary>
        /// Unable to find a valid security descriptor reference domain for this partition.
        /// </summary>
        DsNoRefDomain = 0x0000217F,

        /// <summary>
        /// Schema update failed: The link identifier is reserved.
        /// </summary>
        DsReservedLinkId = 0x00002180,

        /// <summary>
        /// Schema update failed: There are no link identifiers available.
        /// </summary>
        DsLinkIdNotAvailable = 0x00002181,

        /// <summary>
        /// The thread limit for this request was exceeded.
        /// </summary>
        DsThreadLimitExceeded = 0x0000218B,

        /// <summary>
        /// The Global catalog server is not in the closest site.
        /// </summary>
        DsNotClosest = 0x0000218C,

        /// <summary>
        /// The Directory Service cannot parse the script because of a syntax error.
        /// </summary>
        DsNtdscriptSyntaxError = 0x0000218F,

        /// <summary>
        /// The directory service cannot perform the requested operation because the servers involved are of different replication epochs (which is usually related to a domain rename that is in progress).
        /// </summary>
        DsDifferentReplEpochs = 0x00002191,

        /// <summary>
        /// The directory service binding must be renegotiated due to a change in the server extensions information.
        /// </summary>
        DsDrsExtensionsChanged = 0x00002192,

        /// <summary>
        /// Schema update failed: No values for msDS-IntId are available.
        /// </summary>
        DsNoMsdsIntid = 0x00002194,

        /// <summary>
        /// Schema update failed: Duplicate msDS-INtId. Retry the operation.
        /// </summary>
        DsDupMsdsIntid = 0x00002195,

        /// <summary>
        /// Schema deletion failed: attribute is used in rDNAttID.
        /// </summary>
        DsExistsInRdnattid = 0x00002196,

        /// <summary>
        /// The directory service failed to authorize the request.
        /// </summary>
        DsAuthorizationFailed = 0x00002197,

        /// <summary>
        /// The Directory Service cannot process the script because it is invalid.
        /// </summary>
        DsInvalidScript = 0x00002198,

        /// <summary>
        /// A cross reference is in use locally with the same name.
        /// </summary>
        DsCrossRefBusy = 0x0000219A,

        /// <summary>
        /// The requested object has a non-unique identifier and cannot be retrieved.
        /// </summary>
        DsDuplicateIdFound = 0x0000219D,

        /// <summary>
        /// The group cannot be converted due to attribute restrictions on the requested group type.
        /// </summary>
        DsGroupConversionError = 0x0000219F,

        /// <summary>
        /// The FSMO role ownership could not be verified because its directory partition has not replicated successfully with at least one replication partner.
        /// </summary>
        DsRoleNotVerified = 0x000021A2,

        /// <summary>
        /// The directory service detected a child partition below the requested partition name. The partition hierarchy must be created in a top down method.
        /// </summary>
        DsExistingAdChildNc = 0x000021A5,

        /// <summary>
        /// The directory service cannot replicate with this server because the time since the last replication with this server has exceeded the tombstone lifetime.
        /// </summary>
        DsReplLifetimeExceeded = 0x000021A6,

        /// <summary>
        /// The LDAP servers network send queue has filled up because the client is not processing the results of its requests fast enough. No more requests will be processed until the client catches up. If the client does not catch up then it will be disconnected.
        /// </summary>
        DsLdapSendQueueFull = 0x000021A8,

        /// <summary>
        /// At this time, it cannot be determined if the branch replication policy is available on the hub domain controller. Please retry at a later time to account for replication latencies.
        /// </summary>
        DsPolicyNotKnown = 0x000021AA,

        /// <summary>
        /// The site settings object for the specified site does not exist.
        /// </summary>
        NoSiteSettingsObject = 0x000021AB,

        /// <summary>
        /// The local account store does not contain secret material for the specified account.
        /// </summary>
        NoSecrets = 0x000021AC,

        /// <summary>
        /// Could not find a writable domain controller in the domain.
        /// </summary>
        NoWritableDcFound = 0x000021AD,

        /// <summary>
        /// The server object for the domain controller does not exist.
        /// </summary>
        DsNoServerObject = 0x000021AE,

        /// <summary>
        /// The NTDS Settings object for the domain controller does not exist.
        /// </summary>
        DsNoNtdsaObject = 0x000021AF,

        /// <summary>
        /// The requested search operation is not supported for ASQ searches.
        /// </summary>
        DsNonAsqSearch = 0x000021B0,

        /// <summary>
        /// A required audit event could not be generated for the operation.
        /// </summary>
        DsAuditFailure = 0x000021B1,

        /// <summary>
        /// The specified up-to-date-ness vector is corrupt.
        /// </summary>
        DsDraCorruptUtdVector = 0x000021B5,

        /// <summary>
        /// The request to replicate secrets is denied.
        /// </summary>
        DsDraSecretsDenied = 0x000021B6,

        /// <summary>
        /// Schema update failed: The MAPI identifier is reserved.
        /// </summary>
        DsReservedMapiId = 0x000021B7,

        /// <summary>
        /// Schema update failed: There are no MAPI identifiers available.
        /// </summary>
        DsMapiIdNotAvailable = 0x000021B8,

        /// <summary>
        /// The specified OID cannot be found.
        /// </summary>
        DsOidNotFound = 0x000021BE,

        /// <summary>
        /// The replication operation failed because the target object referred by a link value is recycled.
        /// </summary>
        DsDraRecycledTarget = 0x000021BF,

        /// <summary>
        /// The redirect operation failed because the target object is in a NC different from the domain NC of the current domain controller.
        /// </summary>
        DsDisallowedNcRedirect = 0x000021C0,

        /// <summary>
        /// The functional level of the AD LDS configuration set cannot be lowered to the requested value.
        /// </summary>
        DsHighAdldsFfl = 0x000021C1,

        /// <summary>
        /// The functional level of the domain (or forest) cannot be lowered to the requested value.
        /// </summary>
        DsHighDsaVersion = 0x000021C2,

        /// <summary>
        /// The functional level of the AD LDS configuration set cannot be raised to the requested value, because there exist one or more ADLDS instances that are at a lower incompatible functional level.
        /// </summary>
        DsLowAdldsFfl = 0x000021C3,

        /// <summary>
        /// The system is not authoritative for the specified account and therefore cannot complete the operation. Please retry the operation using the provider associated with this account. If this is an online provider please use the provider's online site.
        /// </summary>
        IncorrectAccountType = 0x000021C6,

        /// <summary>
        /// DNS server unable to interpret format.
        /// </summary>
        DnsRcodeFormatError = 0x00002329,

        /// <summary>
        /// DNS server failure.
        /// </summary>
        DnsRcodeServerFailure = 0x0000232A,

        /// <summary>
        /// DNS name does not exist.
        /// </summary>
        DnsRcodeNameError = 0x0000232B,

        /// <summary>
        /// DNS request not supported by name server.
        /// </summary>
        DnsRcodeNotImplemented = 0x0000232C,

        /// <summary>
        /// DNS operation refused.
        /// </summary>
        DnsRcodeRefused = 0x0000232D,

        /// <summary>
        /// DNS name that ought not exist, does exist.
        /// </summary>
        DnsRcodeYxdomain = 0x0000232E,

        /// <summary>
        /// DNS RR set that ought not exist, does exist.
        /// </summary>
        DnsRcodeYxrrset = 0x0000232F,

        /// <summary>
        /// DNS RR set that ought to exist, does not exist.
        /// </summary>
        DnsRcodeNxrrset = 0x00002330,

        /// <summary>
        /// DNS server not authoritative for zone.
        /// </summary>
        DnsRcodeNotauth = 0x00002331,

        /// <summary>
        /// DNS name in update or prereq is not in zone.
        /// </summary>
        DnsRcodeNotzone = 0x00002332,

        /// <summary>
        /// DNS signature failed to verify.
        /// </summary>
        DnsRcodeBadsig = 0x00002338,

        /// <summary>
        /// DNS bad key.
        /// </summary>
        DnsRcodeBadkey = 0x00002339,

        /// <summary>
        /// DNS signature validity expired.
        /// </summary>
        DnsRcodeBadtime = 0x0000233A,

        /// <summary>
        /// Only the DNS server acting as the key master for the zone may perform this operation.
        /// </summary>
        DnsKeymasterRequired = 0x0000238D,

        /// <summary>
        /// The specified algorithm is not supported.
        /// </summary>
        DnsUnsupportedAlgorithm = 0x00002391,

        /// <summary>
        /// The specified key size is not supported.
        /// </summary>
        DnsInvalidKeySize = 0x00002392,

        /// <summary>
        /// An unexpected crypto error was encountered. Zone signing may not be operational until this error is resolved.
        /// </summary>
        DnsUnexpectedCngError = 0x00002396,

        /// <summary>
        /// The specified key service provider cannot be opened by the DNS server.
        /// </summary>
        DnsKspNotAccessible = 0x00002398,

        /// <summary>
        /// The DNS server cannot accept any more signing keys with the specified algorithm and KSK flag value for this zone.
        /// </summary>
        DnsTooManySkds = 0x00002399,

        /// <summary>
        /// The specified signing key is already in process of rolling over keys.
        /// </summary>
        DnsRolloverInProgress = 0x0000239C,

        /// <summary>
        /// This operation is not allowed on a zone signing key (ZSK).
        /// </summary>
        DnsNotAllowedOnZsk = 0x0000239E,

        /// <summary>
        /// This operation could not be completed because the DNS server listed as the current key master for this zone is down or misconfigured. Resolve the problem on the current key master for this zone or use another DNS server to seize the key master role.
        /// </summary>
        DnsBadKeymaster = 0x000023A2,

        /// <summary>
        /// This operation could not be completed because the DNS server has been configured with DNSSEC features disabled. Enable DNSSEC on the DNS server.
        /// </summary>
        DnsDnssecIsDisabled = 0x000023A5,

        /// <summary>
        /// This operation could not be completed because the XML stream received is empty or syntactically invalid.
        /// </summary>
        DnsInvalidXml = 0x000023A6,

        /// <summary>
        /// The specified signing key is not waiting for parental DS update.
        /// </summary>
        DnsRolloverNotPokeable = 0x000023A8,

        /// <summary>
        /// Hash collision detected during NSEC3 signing. Specify a different user-provided salt, or use a randomly generated salt, and attempt to sign the zone again.
        /// </summary>
        DnsNsec3NameCollision = 0x000023A9,

        /// <summary>
        /// No records found for given DNS query.
        /// </summary>
        DnsInfoNoRecords = 0x0000251D,

        /// <summary>
        /// Bad DNS packet.
        /// </summary>
        DnsBadPacket = 0x0000251E,

        /// <summary>
        /// No DNS packet.
        /// </summary>
        DnsNoPacket = 0x0000251F,

        /// <summary>
        /// DNS error, check rcode.
        /// </summary>
        DnsRcode = 0x00002520,

        /// <summary>
        /// Unsecured DNS packet.
        /// </summary>
        DnsUnsecurePacket = 0x00002521,

        /// <summary>
        /// DNS query request is pending.
        /// </summary>
        DnsRequestPending = 0x00002522,

        /// <summary>
        /// Invalid DNS type.
        /// </summary>
        DnsInvalidType = 0x0000254F,

        /// <summary>
        /// Invalid IP address.
        /// </summary>
        DnsInvalidIpAddress = 0x00002550,

        /// <summary>
        /// Invalid property.
        /// </summary>
        DnsInvalidProperty = 0x00002551,

        /// <summary>
        /// Try DNS operation again later.
        /// </summary>
        DnsTryAgainLater = 0x00002552,

        /// <summary>
        /// Record for given name and type is not unique.
        /// </summary>
        DnsNotUnique = 0x00002553,

        /// <summary>
        /// DNS name does not comply with RFC specifications.
        /// </summary>
        DnsNonRfcName = 0x00002554,

        /// <summary>
        /// DNS name is a fully-qualified DNS name.
        /// </summary>
        DnsStatusFqdn = 0x00002555,

        /// <summary>
        /// DNS name is dotted (multi-label).
        /// </summary>
        DnsStatusDottedName = 0x00002556,

        /// <summary>
        /// DNS name is a single-part name.
        /// </summary>
        DnsStatusSinglePartName = 0x00002557,

        /// <summary>
        /// DNS name contains an invalid character.
        /// </summary>
        DnsInvalidNameChar = 0x00002558,

        /// <summary>
        /// DNS name is entirely numeric.
        /// </summary>
        DnsNumericName = 0x00002559,

        /// <summary>
        /// The specified value is too small for this parameter.
        /// </summary>
        DnsDwordValueTooSmall = 0x0000255E,

        /// <summary>
        /// The specified value is too large for this parameter.
        /// </summary>
        DnsDwordValueTooLarge = 0x0000255F,

        /// <summary>
        /// This operation is not allowed while the DNS server is loading zones in the background. Please try again later.
        /// </summary>
        DnsBackgroundLoading = 0x00002560,

        /// <summary>
        /// The operation requested is not permitted on against a DNS server running on a read-only DC.
        /// </summary>
        DnsNotAllowedOnRodc = 0x00002561,

        /// <summary>
        /// This operation requires credentials delegation.
        /// </summary>
        DnsDelegationRequired = 0x00002563,

        /// <summary>
        /// Name resolution policy table has been corrupted. DNS resolution will fail until it is fixed. Contact your network administrator.
        /// </summary>
        DnsInvalidPolicyTable = 0x00002564,

        /// <summary>
        /// DNS zone does not exist.
        /// </summary>
        DnsZoneDoesNotExist = 0x00002581,

        /// <summary>
        /// DNS zone information not available.
        /// </summary>
        DnsNoZoneInfo = 0x00002582,

        /// <summary>
        /// DNS zone is locked.
        /// </summary>
        DnsZoneLocked = 0x00002587,

        /// <summary>
        /// DNS zone creation failed.
        /// </summary>
        DnsZoneCreationFailed = 0x00002588,

        /// <summary>
        /// DNS zone already exists.
        /// </summary>
        DnsZoneAlreadyExists = 0x00002589,

        /// <summary>
        /// Invalid DNS zone type.
        /// </summary>
        DnsInvalidZoneType = 0x0000258B,

        /// <summary>
        /// DNS zone not secondary.
        /// </summary>
        DnsZoneNotSecondary = 0x0000258D,

        /// <summary>
        /// WINS initialization failed.
        /// </summary>
        DnsWinsInitFailed = 0x0000258F,

        /// <summary>
        /// Need WINS servers.
        /// </summary>
        DnsNeedWinsServers = 0x00002590,

        /// <summary>
        /// NBTSTAT initialization call failed.
        /// </summary>
        DnsNbstatInitFailed = 0x00002591,

        /// <summary>
        /// Invalid delete of start of authority (SOA)
        /// </summary>
        DnsSoaDeleteInvalid = 0x00002592,

        /// <summary>
        /// The operation cannot be performed because this zone is shut down.
        /// </summary>
        DnsZoneIsShutdown = 0x00002595,

        /// <summary>
        /// Invalid datafile name for DNS zone.
        /// </summary>
        DnsInvalidDatafileName = 0x000025B4,

        /// <summary>
        /// Failed to open datafile for DNS zone.
        /// </summary>
        DnsDatafileOpenFailure = 0x000025B5,

        /// <summary>
        /// Failed to write datafile for DNS zone.
        /// </summary>
        DnsFileWritebackFailed = 0x000025B6,

        /// <summary>
        /// Failure while reading datafile for DNS zone.
        /// </summary>
        DnsDatafileParsing = 0x000025B7,

        /// <summary>
        /// DNS record does not exist.
        /// </summary>
        DnsRecordDoesNotExist = 0x000025E5,

        /// <summary>
        /// DNS record format error.
        /// </summary>
        DnsRecordFormat = 0x000025E6,

        /// <summary>
        /// Node creation failure in DNS.
        /// </summary>
        DnsNodeCreationFailed = 0x000025E7,

        /// <summary>
        /// Unknown DNS record type.
        /// </summary>
        DnsUnknownRecordType = 0x000025E8,

        /// <summary>
        /// DNS record timed out.
        /// </summary>
        DnsRecordTimedOut = 0x000025E9,

        /// <summary>
        /// Name not in DNS zone.
        /// </summary>
        DnsNameNotInZone = 0x000025EA,

        /// <summary>
        /// CNAME loop detected.
        /// </summary>
        DnsCnameLoop = 0x000025EB,

        /// <summary>
        /// Node is a CNAME DNS record.
        /// </summary>
        DnsNodeIsCname = 0x000025EC,

        /// <summary>
        /// A CNAME record already exists for given name.
        /// </summary>
        DnsCnameCollision = 0x000025ED,

        /// <summary>
        /// DNS record already exists.
        /// </summary>
        DnsRecordAlreadyExists = 0x000025EF,

        /// <summary>
        /// Secondary DNS zone data error.
        /// </summary>
        DnsSecondaryData = 0x000025F0,

        /// <summary>
        /// Could not create DNS cache data.
        /// </summary>
        DnsNoCreateCacheData = 0x000025F1,

        /// <summary>
        /// DNS name does not exist.
        /// </summary>
        DnsNameDoesNotExist = 0x000025F2,

        /// <summary>
        /// Could not create pointer (PTR) record.
        /// </summary>
        DnsWarningPtrCreateFailed = 0x000025F3,

        /// <summary>
        /// DNS domain was undeleted.
        /// </summary>
        DnsWarningDomainUndeleted = 0x000025F4,

        /// <summary>
        /// The directory service is unavailable.
        /// </summary>
        DnsDsUnavailable = 0x000025F5,

        /// <summary>
        /// Node is a DNAME DNS record.
        /// </summary>
        DnsNodeIsDname = 0x000025F8,

        /// <summary>
        /// A DNAME record already exists for given name.
        /// </summary>
        DnsDnameCollision = 0x000025F9,

        /// <summary>
        /// An alias loop has been detected with either CNAME or DNAME records.
        /// </summary>
        DnsAliasLoop = 0x000025FA,

        /// <summary>
        /// DNS AXFR (zone transfer) complete.
        /// </summary>
        DnsInfoAxfrComplete = 0x00002617,

        /// <summary>
        /// DNS zone transfer failed.
        /// </summary>
        DnsAxfr = 0x00002618,

        /// <summary>
        /// Added local WINS server.
        /// </summary>
        DnsInfoAddedLocalWins = 0x00002619,

        /// <summary>
        /// Secure update call needs to continue update request.
        /// </summary>
        DnsStatusContinueNeeded = 0x00002649,

        /// <summary>
        /// TCP/IP network protocol not installed.
        /// </summary>
        DnsNoTcpip = 0x0000267B,

        /// <summary>
        /// No DNS servers configured for local system.
        /// </summary>
        DnsNoDnsServers = 0x0000267C,

        /// <summary>
        /// The specified directory partition does not exist.
        /// </summary>
        DnsDpDoesNotExist = 0x000026AD,

        /// <summary>
        /// The specified directory partition already exists.
        /// </summary>
        DnsDpAlreadyExists = 0x000026AE,

        /// <summary>
        /// This DNS server is not enlisted in the specified directory partition.
        /// </summary>
        DnsDpNotEnlisted = 0x000026AF,

        /// <summary>
        /// This DNS server is already enlisted in the specified directory partition.
        /// </summary>
        DnsDpAlreadyEnlisted = 0x000026B0,

        /// <summary>
        /// The directory partition is not available at this time. Please wait a few minutes and try again.
        /// </summary>
        DnsDpNotAvailable = 0x000026B1,

        /// <summary>
        /// The operation failed because the domain naming master FSMO role could not be reached. The domain controller holding the domain naming master FSMO role is down or unable to service the request or is not running Windows Server 2003 or later.
        /// </summary>
        DnsDpFsmoError = 0x000026B2,

        /// <summary>
        /// The scope is the same as the default zone scope.
        /// </summary>
        DnsDefaultZonescope = 0x000026E1,

        /// <summary>
        /// Failed to load zone scope.
        /// </summary>
        DnsLoadZonescopeFailed = 0x000026E4,

        /// <summary>
        /// The scope name contains invalid characters.
        /// </summary>
        DnsInvalidScopeName = 0x000026E6,

        /// <summary>
        /// The scope does not exist.
        /// </summary>
        DnsScopeDoesNotExist = 0x000026E7,

        /// <summary>
        /// The scope is the same as the default scope.
        /// </summary>
        DnsDefaultScope = 0x000026E8,

        /// <summary>
        /// The scope is locked.
        /// </summary>
        DnsScopeLocked = 0x000026EA,

        /// <summary>
        /// The scope already exists.
        /// </summary>
        DnsScopeAlreadyExists = 0x000026EB,

        /// <summary>
        /// A blocking operation was interrupted by a call to WSACancelBlockingCall.
        /// </summary>
        Wsaeintr = 0x00002714,

        /// <summary>
        /// The file handle supplied is not valid.
        /// </summary>
        Wsaebadf = 0x00002719,

        /// <summary>
        /// An attempt was made to access a socket in a way forbidden by its access permissions.
        /// </summary>
        Wsaeacces = 0x0000271D,

        /// <summary>
        /// The system detected an invalid pointer address in attempting to use a pointer argument in a call.
        /// </summary>
        Wsaefault = 0x0000271E,

        /// <summary>
        /// An invalid argument was supplied.
        /// </summary>
        Wsaeinval = 0x00002726,

        /// <summary>
        /// Too many open sockets.
        /// </summary>
        Wsaemfile = 0x00002728,

        /// <summary>
        /// A non-blocking socket operation could not be completed immediately.
        /// </summary>
        Wsaewouldblock = 0x00002733,

        /// <summary>
        /// A blocking operation is currently executing.
        /// </summary>
        Wsaeinprogress = 0x00002734,

        /// <summary>
        /// An operation was attempted on a non-blocking socket that already had an operation in progress.
        /// </summary>
        Wsaealready = 0x00002735,

        /// <summary>
        /// An operation was attempted on something that is not a socket.
        /// </summary>
        Wsaenotsock = 0x00002736,

        /// <summary>
        /// A required address was omitted from an operation on a socket.
        /// </summary>
        Wsaedestaddrreq = 0x00002737,

        /// <summary>
        /// A message sent on a datagram socket was larger than the internal message buffer or some other network limit, or the buffer used to receive a datagram into was smaller than the datagram itself.
        /// </summary>
        Wsaemsgsize = 0x00002738,

        /// <summary>
        /// A protocol was specified in the socket function call that does not support the semantics of the socket type requested.
        /// </summary>
        Wsaeprototype = 0x00002739,

        /// <summary>
        /// An unknown, invalid, or unsupported option or level was specified in a getsockopt or setsockopt call.
        /// </summary>
        Wsaenoprotoopt = 0x0000273A,

        /// <summary>
        /// The requested protocol has not been configured into the system, or no implementation for it exists.
        /// </summary>
        Wsaeprotonosupport = 0x0000273B,

        /// <summary>
        /// The support for the specified socket type does not exist in this address family.
        /// </summary>
        Wsaesocktnosupport = 0x0000273C,

        /// <summary>
        /// The attempted operation is not supported for the type of object referenced.
        /// </summary>
        Wsaeopnotsupp = 0x0000273D,

        /// <summary>
        /// The protocol family has not been configured into the system or no implementation for it exists.
        /// </summary>
        Wsaepfnosupport = 0x0000273E,

        /// <summary>
        /// An address incompatible with the requested protocol was used.
        /// </summary>
        Wsaeafnosupport = 0x0000273F,

        /// <summary>
        /// Only one usage of each socket address (protocol/network address/port) is normally permitted.
        /// </summary>
        Wsaeaddrinuse = 0x00002740,

        /// <summary>
        /// The requested address is not valid in its context.
        /// </summary>
        Wsaeaddrnotavail = 0x00002741,

        /// <summary>
        /// A socket operation encountered a dead network.
        /// </summary>
        Wsaenetdown = 0x00002742,

        /// <summary>
        /// A socket operation was attempted to an unreachable network.
        /// </summary>
        Wsaenetunreach = 0x00002743,

        /// <summary>
        /// The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress.
        /// </summary>
        Wsaenetreset = 0x00002744,

        /// <summary>
        /// An established connection was aborted by the software in your host machine.
        /// </summary>
        Wsaeconnaborted = 0x00002745,

        /// <summary>
        /// An existing connection was forcibly closed by the remote host.
        /// </summary>
        Wsaeconnreset = 0x00002746,

        /// <summary>
        /// An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full.
        /// </summary>
        Wsaenobufs = 0x00002747,

        /// <summary>
        /// A connect request was made on an already connected socket.
        /// </summary>
        Wsaeisconn = 0x00002748,

        /// <summary>
        /// A request to send or receive data was disallowed because the socket is not connected and (when sending on a datagram socket using a sendto call) no address was supplied.
        /// </summary>
        Wsaenotconn = 0x00002749,

        /// <summary>
        /// A request to send or receive data was disallowed because the socket had already been shut down in that direction with a previous shutdown call.
        /// </summary>
        Wsaeshutdown = 0x0000274A,

        /// <summary>
        /// Too many references to some kernel object.
        /// </summary>
        Wsaetoomanyrefs = 0x0000274B,

        /// <summary>
        /// A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.
        /// </summary>
        Wsaetimedout = 0x0000274C,

        /// <summary>
        /// No connection could be made because the target machine actively refused it.
        /// </summary>
        Wsaeconnrefused = 0x0000274D,

        /// <summary>
        /// Cannot translate name.
        /// </summary>
        Wsaeloop = 0x0000274E,

        /// <summary>
        /// Name component or name was too long.
        /// </summary>
        Wsaenametoolong = 0x0000274F,

        /// <summary>
        /// A socket operation failed because the destination host was down.
        /// </summary>
        Wsaehostdown = 0x00002750,

        /// <summary>
        /// A socket operation was attempted to an unreachable host.
        /// </summary>
        Wsaehostunreach = 0x00002751,

        /// <summary>
        /// Cannot remove a directory that is not empty.
        /// </summary>
        Wsaenotempty = 0x00002752,

        /// <summary>
        /// A Windows Sockets implementation may have a limit on the number of applications that may use it simultaneously.
        /// </summary>
        Wsaeproclim = 0x00002753,

        /// <summary>
        /// Ran out of quota.
        /// </summary>
        Wsaeusers = 0x00002754,

        /// <summary>
        /// Ran out of disk quota.
        /// </summary>
        Wsaedquot = 0x00002755,

        /// <summary>
        /// File handle reference is no longer available.
        /// </summary>
        Wsaestale = 0x00002756,

        /// <summary>
        /// Item is not available locally.
        /// </summary>
        Wsaeremote = 0x00002757,

        /// <summary>
        /// WSAStartup cannot function at this time because the underlying system it uses to provide network services is currently unavailable.
        /// </summary>
        Wsasysnotready = 0x0000276B,

        /// <summary>
        /// The Windows Sockets version requested is not supported.
        /// </summary>
        Wsavernotsupported = 0x0000276C,

        /// <summary>
        /// Either the application has not called WSAStartup, or WSAStartup failed.
        /// </summary>
        Wsanotinitialised = 0x0000276D,

        /// <summary>
        /// Returned by WSARecv or WSARecvFrom to indicate the remote party has initiated a graceful shutdown sequence.
        /// </summary>
        Wsaediscon = 0x00002775,

        /// <summary>
        /// No more results can be returned by WSALookupServiceNext.
        /// </summary>
        Wsaenomore = 0x00002776,

        /// <summary>
        /// A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled.
        /// </summary>
        Wsaecancelled = 0x00002777,

        /// <summary>
        /// The procedure call table is invalid.
        /// </summary>
        Wsaeinvalidproctable = 0x00002778,

        /// <summary>
        /// The requested service provider is invalid.
        /// </summary>
        Wsaeinvalidprovider = 0x00002779,

        /// <summary>
        /// The requested service provider could not be loaded or initialized.
        /// </summary>
        Wsaeproviderfailedinit = 0x0000277A,

        /// <summary>
        /// A system call has failed.
        /// </summary>
        Wsasyscallfailure = 0x0000277B,

        /// <summary>
        /// No such service is known. The service cannot be found in the specified name space.
        /// </summary>
        WsaserviceNotFound = 0x0000277C,

        /// <summary>
        /// The specified class was not found.
        /// </summary>
        WsatypeNotFound = 0x0000277D,

        /// <summary>
        /// No more results can be returned by WSALookupServiceNext.
        /// </summary>
        WsaENoMore = 0x0000277E,

        /// <summary>
        /// A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled.
        /// </summary>
        WsaECancelled = 0x0000277F,

        /// <summary>
        /// A database query failed because it was actively refused.
        /// </summary>
        Wsaerefused = 0x00002780,

        /// <summary>
        /// No such host is known.
        /// </summary>
        WsahostNotFound = 0x00002AF9,

        /// <summary>
        /// This is usually a temporary error during hostname resolution and means that the local server did not receive a response from an authoritative server.
        /// </summary>
        WsatryAgain = 0x00002AFA,

        /// <summary>
        /// A non-recoverable error occurred during a database lookup.
        /// </summary>
        WsanoRecovery = 0x00002AFB,

        /// <summary>
        /// The requested name is valid, but no data of the requested type was found.
        /// </summary>
        WsanoData = 0x00002AFC,

        /// <summary>
        /// At least one reserve has arrived.
        /// </summary>
        WsaQosReceivers = 0x00002AFD,

        /// <summary>
        /// At least one path has arrived.
        /// </summary>
        WsaQosSenders = 0x00002AFE,

        /// <summary>
        /// There are no senders.
        /// </summary>
        WsaQosNoSenders = 0x00002AFF,

        /// <summary>
        /// There are no receivers.
        /// </summary>
        WsaQosNoReceivers = 0x00002B00,

        /// <summary>
        /// Reserve has been confirmed.
        /// </summary>
        WsaQosRequestConfirmed = 0x00002B01,

        /// <summary>
        /// Error due to lack of resources.
        /// </summary>
        WsaQosAdmissionFailure = 0x00002B02,

        /// <summary>
        /// Rejected for administrative reasons - bad credentials.
        /// </summary>
        WsaQosPolicyFailure = 0x00002B03,

        /// <summary>
        /// Unknown or conflicting style.
        /// </summary>
        WsaQosBadStyle = 0x00002B04,

        /// <summary>
        /// Problem with some part of the filterspec or providerspecific buffer in general.
        /// </summary>
        WsaQosBadObject = 0x00002B05,

        /// <summary>
        /// Problem with some part of the flowspec.
        /// </summary>
        WsaQosTrafficCtrlError = 0x00002B06,

        /// <summary>
        /// General QOS error.
        /// </summary>
        WsaQosGenericError = 0x00002B07,

        /// <summary>
        /// An invalid or unrecognized service type was found in the flowspec.
        /// </summary>
        WsaQosEservicetype = 0x00002B08,

        /// <summary>
        /// An invalid or inconsistent flowspec was found in the QOS structure.
        /// </summary>
        WsaQosEflowspec = 0x00002B09,

        /// <summary>
        /// Invalid QOS provider-specific buffer.
        /// </summary>
        WsaQosEprovspecbuf = 0x00002B0A,

        /// <summary>
        /// An invalid QOS filter style was used.
        /// </summary>
        WsaQosEfilterstyle = 0x00002B0B,

        /// <summary>
        /// An invalid QOS filter type was used.
        /// </summary>
        WsaQosEfiltertype = 0x00002B0C,

        /// <summary>
        /// An incorrect number of QOS FILTERSPECs were specified in the FLOWDESCRIPTOR.
        /// </summary>
        WsaQosEfiltercount = 0x00002B0D,

        /// <summary>
        /// An object with an invalid ObjectLength field was specified in the QOS provider-specific buffer.
        /// </summary>
        WsaQosEobjlength = 0x00002B0E,

        /// <summary>
        /// An incorrect number of flow descriptors was specified in the QOS structure.
        /// </summary>
        WsaQosEflowcount = 0x00002B0F,

        /// <summary>
        /// An unrecognized object was found in the QOS provider-specific buffer.
        /// </summary>
        WsaQosEunkownpsobj = 0x00002B10,

        /// <summary>
        /// An invalid policy object was found in the QOS provider-specific buffer.
        /// </summary>
        WsaQosEpolicyobj = 0x00002B11,

        /// <summary>
        /// An invalid QOS flow descriptor was found in the flow descriptor list.
        /// </summary>
        WsaQosEflowdesc = 0x00002B12,

        /// <summary>
        /// An invalid or inconsistent flowspec was found in the QOS provider specific buffer.
        /// </summary>
        WsaQosEpsflowspec = 0x00002B13,

        /// <summary>
        /// An invalid FILTERSPEC was found in the QOS provider-specific buffer.
        /// </summary>
        WsaQosEpsfilterspec = 0x00002B14,

        /// <summary>
        /// An invalid shape discard mode object was found in the QOS provider specific buffer.
        /// </summary>
        WsaQosEsdmodeobj = 0x00002B15,

        /// <summary>
        /// An invalid shaping rate object was found in the QOS provider-specific buffer.
        /// </summary>
        WsaQosEshaperateobj = 0x00002B16,

        /// <summary>
        /// A reserved policy element was found in the QOS provider-specific buffer.
        /// </summary>
        WsaQosReservedPetype = 0x00002B17,

        /// <summary>
        /// No such host is known securely.
        /// </summary>
        WsaSecureHostNotFound = 0x00002B18,

        /// <summary>
        /// Name based IPSEC policy could not be added.
        /// </summary>
        WsaIpsecNamePolicyError = 0x00002B19,

        /// <summary>
        /// The specified quick mode policy already exists.
        /// </summary>
        IpsecQmPolicyExists = 0x000032C8,

        /// <summary>
        /// The specified quick mode policy was not found.
        /// </summary>
        IpsecQmPolicyNotFound = 0x000032C9,

        /// <summary>
        /// The specified quick mode policy is being used.
        /// </summary>
        IpsecQmPolicyInUse = 0x000032CA,

        /// <summary>
        /// The specified main mode policy already exists.
        /// </summary>
        IpsecMmPolicyExists = 0x000032CB,

        /// <summary>
        /// The specified main mode policy was not found
        /// </summary>
        IpsecMmPolicyNotFound = 0x000032CC,

        /// <summary>
        /// The specified main mode policy is being used.
        /// </summary>
        IpsecMmPolicyInUse = 0x000032CD,

        /// <summary>
        /// The specified main mode filter already exists.
        /// </summary>
        IpsecMmFilterExists = 0x000032CE,

        /// <summary>
        /// The specified main mode filter was not found.
        /// </summary>
        IpsecMmFilterNotFound = 0x000032CF,

        /// <summary>
        /// The specified main mode authentication list exists.
        /// </summary>
        IpsecMmAuthExists = 0x000032D2,

        /// <summary>
        /// The specified main mode authentication list was not found.
        /// </summary>
        IpsecMmAuthNotFound = 0x000032D3,

        /// <summary>
        /// The specified main mode authentication list is being used.
        /// </summary>
        IpsecMmAuthInUse = 0x000032D4,

        /// <summary>
        /// The Main Mode policy was successfully added, but some of the requested offers are not supported.
        /// </summary>
        WarningIpsecMmPolicyPruned = 0x000032E0,

        /// <summary>
        /// The Quick Mode policy was successfully added, but some of the requested offers are not supported.
        /// </summary>
        WarningIpsecQmPolicyPruned = 0x000032E1,

        /// <summary>
        /// IKE authentication credentials are unacceptable
        /// </summary>
        IpsecIkeAuthFail = 0x000035E9,

        /// <summary>
        /// IKE security attributes are unacceptable
        /// </summary>
        IpsecIkeAttribFail = 0x000035EA,

        /// <summary>
        /// Negotiation timed out
        /// </summary>
        IpsecIkeTimedOut = 0x000035ED,

        /// <summary>
        /// IKE failed to find valid machine certificate. Contact your Network Security Administrator about installing a valid certificate in the appropriate Certificate Store.
        /// </summary>
        IpsecIkeNoCert = 0x000035EE,

        /// <summary>
        /// IKE SA deleted by peer before establishment completed
        /// </summary>
        IpsecIkeSaDeleted = 0x000035EF,

        /// <summary>
        /// IKE SA deleted before establishment completed
        /// </summary>
        IpsecIkeSaReaped = 0x000035F0,

        /// <summary>
        /// Negotiation request sat in Queue too long
        /// </summary>
        IpsecIkeMmAcquireDrop = 0x000035F1,

        /// <summary>
        /// Negotiation request sat in Queue too long
        /// </summary>
        IpsecIkeQmAcquireDrop = 0x000035F2,

        /// <summary>
        /// Negotiation request sat in Queue too long
        /// </summary>
        IpsecIkeQueueDropMm = 0x000035F3,

        /// <summary>
        /// Negotiation took too long
        /// </summary>
        IpsecIkeMmDelayDrop = 0x000035F6,

        /// <summary>
        /// Negotiation took too long
        /// </summary>
        IpsecIkeQmDelayDrop = 0x000035F7,

        /// <summary>
        /// Unknown error occurred
        /// </summary>
        IpsecIkeError = 0x000035F8,

        /// <summary>
        /// Certificate Revocation Check failed
        /// </summary>
        IpsecIkeCrlFailed = 0x000035F9,

        /// <summary>
        /// IKE negotiation failed because the machine certificate used does not have a private key. IPsec certificates require a private key. Contact your Network Security administrator about replacing with a certificate that has a private key.
        /// </summary>
        IpsecIkeNoPrivateKey = 0x000035FC,

        /// <summary>
        /// Failure in Diffie-Hellman computation
        /// </summary>
        IpsecIkeDhFail = 0x000035FE,

        /// <summary>
        /// Invalid header
        /// </summary>
        IpsecIkeInvalidHeader = 0x00003600,

        /// <summary>
        /// No policy configured
        /// </summary>
        IpsecIkeNoPolicy = 0x00003601,

        /// <summary>
        /// Failed to authenticate using Kerberos
        /// </summary>
        IpsecIkeKerberosError = 0x00003603,

        /// <summary>
        /// Peer's certificate did not have a public key
        /// </summary>
        IpsecIkeNoPublicKey = 0x00003604,

        /// <summary>
        /// Error processing error payload
        /// </summary>
        IpsecIkeProcessErr = 0x00003605,

        /// <summary>
        /// Error processing SA payload
        /// </summary>
        IpsecIkeProcessErrSa = 0x00003606,

        /// <summary>
        /// Error processing KE payload
        /// </summary>
        IpsecIkeProcessErrKe = 0x00003609,

        /// <summary>
        /// Error processing ID payload
        /// </summary>
        IpsecIkeProcessErrId = 0x0000360A,

        /// <summary>
        /// Error processing Signature payload
        /// </summary>
        IpsecIkeProcessErrSig = 0x0000360E,

        /// <summary>
        /// Invalid payload received
        /// </summary>
        IpsecIkeInvalidPayload = 0x00003613,

        /// <summary>
        /// Soft SA loaded
        /// </summary>
        IpsecIkeLoadSoftSa = 0x00003614,

        /// <summary>
        /// Invalid cookie received.
        /// </summary>
        IpsecIkeInvalidCookie = 0x00003616,

        /// <summary>
        /// Peer failed to send valid machine certificate
        /// </summary>
        IpsecIkeNoPeerCert = 0x00003617,

        /// <summary>
        /// Certification Revocation check of peer's certificate failed
        /// </summary>
        IpsecIkePeerCrlFailed = 0x00003618,

        /// <summary>
        /// New policy invalidated SAs formed with old policy
        /// </summary>
        IpsecIkePolicyChange = 0x00003619,

        /// <summary>
        /// There is no available Main Mode IKE policy.
        /// </summary>
        IpsecIkeNoMmPolicy = 0x0000361A,

        /// <summary>
        /// Failed to enabled TCB privilege.
        /// </summary>
        IpsecIkeNotcbpriv = 0x0000361B,

        /// <summary>
        /// Failed to load SECURITY.DLL.
        /// </summary>
        IpsecIkeSecloadfail = 0x0000361C,

        /// <summary>
        /// Failed to obtain security function table dispatch address from SSPI.
        /// </summary>
        IpsecIkeFailsspinit = 0x0000361D,

        /// <summary>
        /// Failed to query Kerberos package to obtain max token size.
        /// </summary>
        IpsecIkeFailqueryssp = 0x0000361E,

        /// <summary>
        /// Failed to obtain Kerberos server credentials for ISAKMP/ERROR_IPSEC_IKE service. Kerberos authentication will not function. The most likely reason for this is lack of domain membership. This is normal if your computer is a member of a workgroup.
        /// </summary>
        IpsecIkeSrvacqfail = 0x0000361F,

        /// <summary>
        /// Failed to determine SSPI principal name for ISAKMP/ERROR_IPSEC_IKE service (QueryCredentialsAttributes).
        /// </summary>
        IpsecIkeSrvquerycred = 0x00003620,

        /// <summary>
        /// Failed to obtain new SPI for the inbound SA from IPsec driver. The most common cause for this is that the driver does not have the correct filter. Check your policy to verify the filters.
        /// </summary>
        IpsecIkeGetspifail = 0x00003621,

        /// <summary>
        /// Given filter is invalid
        /// </summary>
        IpsecIkeInvalidFilter = 0x00003622,

        /// <summary>
        /// Memory allocation failed.
        /// </summary>
        IpsecIkeOutOfMemory = 0x00003623,

        /// <summary>
        /// Invalid policy
        /// </summary>
        IpsecIkeInvalidPolicy = 0x00003625,

        /// <summary>
        /// Invalid DOI
        /// </summary>
        IpsecIkeUnknownDoi = 0x00003626,

        /// <summary>
        /// Diffie-Hellman failure
        /// </summary>
        IpsecIkeDhFailure = 0x00003628,

        /// <summary>
        /// Invalid Diffie-Hellman group
        /// </summary>
        IpsecIkeInvalidGroup = 0x00003629,

        /// <summary>
        /// Error encrypting payload
        /// </summary>
        IpsecIkeEncrypt = 0x0000362A,

        /// <summary>
        /// Error decrypting payload
        /// </summary>
        IpsecIkeDecrypt = 0x0000362B,

        /// <summary>
        /// Policy match error
        /// </summary>
        IpsecIkePolicyMatch = 0x0000362C,

        /// <summary>
        /// Unsupported ID
        /// </summary>
        IpsecIkeUnsupportedId = 0x0000362D,

        /// <summary>
        /// Hash verification failed
        /// </summary>
        IpsecIkeInvalidHash = 0x0000362E,

        /// <summary>
        /// Invalid certificate signature
        /// </summary>
        IpsecIkeInvalidSig = 0x00003633,

        /// <summary>
        /// Load failed
        /// </summary>
        IpsecIkeLoadFailed = 0x00003634,

        /// <summary>
        /// Deleted via RPC call
        /// </summary>
        IpsecIkeRpcDelete = 0x00003635,

        /// <summary>
        /// Temporary state created to perform reinitialization. This is not a real failure.
        /// </summary>
        IpsecIkeBenignReinit = 0x00003636,

        /// <summary>
        /// Max number of established MM SAs to peer exceeded.
        /// </summary>
        IpsecIkeMmLimit = 0x0000363A,

        /// <summary>
        /// Reached maximum quick mode limit for the main mode. New main mode will be started.
        /// </summary>
        IpsecIkeQmLimit = 0x0000363C,

        /// <summary>
        /// Main mode SA lifetime expired or peer sent a main mode delete.
        /// </summary>
        IpsecIkeMmExpired = 0x0000363D,

        /// <summary>
        /// Sent DoS cookie notify to initiator.
        /// </summary>
        IpsecIkeDosCookieSent = 0x00003642,

        /// <summary>
        /// IKE service is shutting down.
        /// </summary>
        IpsecIkeShuttingDown = 0x00003643,

        /// <summary>
        /// Could not verify binding between CGA address and certificate.
        /// </summary>
        IpsecIkeCgaAuthFailed = 0x00003644,

        /// <summary>
        /// Quick mode SA was expired by IPsec driver.
        /// </summary>
        IpsecIkeQmExpired = 0x00003647,

        /// <summary>
        /// ERROR_IPSEC_IKE_NEG_STATUS_END
        /// </summary>
        IpsecIkeNegStatusEnd = 0x00003649,

        /// <summary>
        /// Incoming SA request was dropped due to peer IP address rate limiting.
        /// </summary>
        IpsecIkeRatelimitDrop = 0x0000364F,

        /// <summary>
        /// The SPI in the packet does not match a valid IPsec SA.
        /// </summary>
        IpsecBadSpi = 0x00003656,

        /// <summary>
        /// Packet was received on an IPsec SA whose lifetime has expired.
        /// </summary>
        IpsecSaLifetimeExpired = 0x00003657,

        /// <summary>
        /// Packet was received on an IPsec SA that does not match the packet characteristics.
        /// </summary>
        IpsecWrongSa = 0x00003658,

        /// <summary>
        /// Packet sequence number replay check failed.
        /// </summary>
        IpsecReplayCheckFailed = 0x00003659,

        /// <summary>
        /// IPsec header and/or trailer in the packet is invalid.
        /// </summary>
        IpsecInvalidPacket = 0x0000365A,

        /// <summary>
        /// IPsec dropped a clear text packet.
        /// </summary>
        IpsecClearTextDrop = 0x0000365C,

        /// <summary>
        /// IPsec dropped an incoming ESP packet in authenticated firewall mode. This drop is benign.
        /// </summary>
        IpsecAuthFirewallDrop = 0x0000365D,

        /// <summary>
        /// IPsec dropped a packet due to DoS throttling.
        /// </summary>
        IpsecThrottleDrop = 0x0000365E,

        /// <summary>
        /// IPsec DoS Protection matched an explicit block rule.
        /// </summary>
        IpsecDospBlock = 0x00003665,

        /// <summary>
        /// IPsec DoS Protection received an incorrectly formatted packet.
        /// </summary>
        IpsecDospInvalidPacket = 0x00003667,

        /// <summary>
        /// IPsec DoS Protection failed to create state because the maximum number of entries allowed by policy has been reached.
        /// </summary>
        IpsecDospMaxEntries = 0x00003669,

        /// <summary>
        /// IPsec DoS Protection has not been enabled.
        /// </summary>
        IpsecDospNotInstalled = 0x0000366B,

        /// <summary>
        /// The requested section was not present in the activation context.
        /// </summary>
        SxsSectionNotFound = 0x000036B0,

        /// <summary>
        /// The application has failed to start because its side-by-side configuration is incorrect. Please see the application event log or use the command-line sxstrace.exe tool for more detail.
        /// </summary>
        SxsCantGenActctx = 0x000036B1,

        /// <summary>
        /// The referenced assembly is not installed on your system.
        /// </summary>
        SxsAssemblyNotFound = 0x000036B3,

        /// <summary>
        /// The manifest file does not begin with the required tag and format information.
        /// </summary>
        SxsManifestFormatError = 0x000036B4,

        /// <summary>    /// The manifest file contains one or more syntax errors.
        /// </summary>
        SxsManifestParseError = 0x000036B5,

        /// <summary>
        /// The requested lookup key was not found in any active activation context.
        /// </summary>
        SxsKeyNotFound = 0x000036B7,

        /// <summary>
        /// A component version required by the application conflicts with another component version already active.
        /// </summary>
        SxsVersionConflict = 0x000036B8,

        /// <summary>
        /// The type requested activation context section does not match the query API used.
        /// </summary>
        SxsWrongSectionType = 0x000036B9,

        /// <summary>
        /// The encoding requested is not recognized.
        /// </summary>
        SxsUnknownEncoding = 0x000036BD,

        /// <summary>
        /// Two or more components referenced directly or indirectly by the application manifest have files by the same name.
        /// </summary>
        SxsDuplicateDllName = 0x000036C5,

        /// <summary>
        /// Two or more components referenced directly or indirectly by the application manifest have the same COM server CLSIDs.
        /// </summary>
        SxsDuplicateClsid = 0x000036C7,

        /// <summary>
        /// Two or more components referenced directly or indirectly by the application manifest have proxies for the same COM interface IIDs.
        /// </summary>
        SxsDuplicateIid = 0x000036C8,

        /// <summary>
        /// Two or more components referenced directly or indirectly by the application manifest have the same COM type library TLBIDs.
        /// </summary>
        SxsDuplicateTlbid = 0x000036C9,

        /// <summary>
        /// Two or more components referenced directly or indirectly by the application manifest have the same COM ProgIDs.
        /// </summary>
        SxsDuplicateProgid = 0x000036CA,

        /// <summary>
        /// A component's file does not match the verification information present in the component manifest.
        /// </summary>
        SxsFileHashMismatch = 0x000036CC,

        /// <summary>
        /// The policy manifest contains one or more syntax errors.
        /// </summary>
        SxsPolicyParseError = 0x000036CD,

        /// <summary>
        /// Manifest Parse Error : A string literal was expected, but no opening quote character was found.
        /// </summary>
        SxsXmlEMissingquote = 0x000036CE,

        /// <summary>
        /// Manifest Parse Error : Incorrect syntax was used in a comment.
        /// </summary>
        SxsXmlECommentsyntax = 0x000036CF,

        /// <summary>
        /// Manifest Parse Error : A name contained an invalid character.
        /// </summary>
        SxsXmlEBadnamechar = 0x000036D1,

        /// <summary>
        /// Manifest Parse Error : A string literal contained an invalid character.
        /// </summary>
        SxsXmlEBadcharinstring = 0x000036D2,

        /// <summary>
        /// Manifest Parse Error : Invalid syntax for an xml declaration.
        /// </summary>
        SxsXmlEXmldeclsyntax = 0x000036D3,

        /// <summary>
        /// Manifest Parse Error : An Invalid character was found in text content.
        /// </summary>
        SxsXmlEBadchardata = 0x000036D4,

        /// <summary>
        /// Manifest Parse Error : The character '>' was expected.
        /// </summary>
        SxsXmlEExpectingtagend = 0x000036D6,

        /// <summary>
        /// Manifest Parse Error : Unbalanced parentheses.
        /// </summary>
        SxsXmlEUnbalancedparen = 0x000036D8,

        /// <summary>
        /// Manifest Parse Error : Internal error.
        /// </summary>
        SxsXmlEInternalerror = 0x000036D9,

        /// <summary>
        /// Manifest Parse Error : Missing parenthesis.
        /// </summary>
        SxsXmlEMissingParen = 0x000036DC,

        /// <summary>
        /// Manifest Parse Error : Multiple colons are not allowed in a name.
        /// </summary>
        SxsXmlEMultipleColons = 0x000036DE,

        /// <summary>
        /// Manifest Parse Error : Invalid character for decimal digit.
        /// </summary>
        SxsXmlEInvalidDecimal = 0x000036DF,

        /// <summary>
        /// Manifest Parse Error : Invalid unicode character value for this platform.
        /// </summary>
        SxsXmlEInvalidUnicode = 0x000036E1,

        /// <summary>
        /// Manifest Parse Error : The following tags were not closed: %1.
        /// </summary>
        SxsXmlEUnclosedtag = 0x000036E4,

        /// <summary>
        /// Manifest Parse Error : Only one top level element is allowed in an XML document.
        /// </summary>
        SxsXmlEMultipleroots = 0x000036E6,

        /// <summary>
        /// Manifest Parse Error : Invalid xml declaration.
        /// </summary>
        SxsXmlEBadxmldecl = 0x000036E8,

        /// <summary>
        /// Manifest Parse Error : XML document must have a top level element.
        /// </summary>
        SxsXmlEMissingroot = 0x000036E9,

        /// <summary>
        /// Manifest Parse Error : Unexpected end of file.
        /// </summary>
        SxsXmlEUnexpectedeof = 0x000036EA,

        /// <summary>
        /// Manifest Parse Error : End element was missing the character '>'.
        /// </summary>
        SxsXmlEUnclosedendtag = 0x000036ED,

        /// <summary>
        /// Manifest Parse Error : A string literal was not closed.
        /// </summary>
        SxsXmlEUnclosedstring = 0x000036EE,

        /// <summary>
        /// Manifest Parse Error : A comment was not closed.
        /// </summary>
        SxsXmlEUnclosedcomment = 0x000036EF,

        /// <summary>
        /// Manifest Parse Error : A declaration was not closed.
        /// </summary>
        SxsXmlEUncloseddecl = 0x000036F0,

        /// <summary>
        /// Manifest Parse Error : A CDATA section was not closed.
        /// </summary>
        SxsXmlEUnclosedcdata = 0x000036F1,

        /// <summary>
        /// Manifest Parse Error : System does not support the specified encoding.
        /// </summary>
        SxsXmlEInvalidencoding = 0x000036F3,

        /// <summary>
        /// Manifest Parse Error : Switch from current encoding to specified encoding not supported.
        /// </summary>
        SxsXmlEInvalidswitch = 0x000036F4,

        /// <summary>
        /// Manifest Parse Error : The name 'xml' is reserved and must be lower case.
        /// </summary>
        SxsXmlEBadxmlcase = 0x000036F5,

        /// <summary>
        /// Manifest Parse Error : Invalid version number.
        /// </summary>
        SxsXmlEInvalidVersion = 0x000036F8,

        /// <summary>
        /// Manifest Parse Error : Missing equals sign between attribute and attribute value.
        /// </summary>
        SxsXmlEMissingequals = 0x000036F9,

        /// <summary>
        /// The referenced assembly could not be found.
        /// </summary>
        SxsAssemblyMissing = 0x00003701,

        /// <summary>
        /// The application isolation metadata for this process or thread has become corrupt.
        /// </summary>
        SxsCorruption = 0x00003703,

        /// <summary>
        /// The activation context being deactivated is not the most recently activated one.
        /// </summary>
        SxsEarlyDeactivation = 0x00003704,

        /// <summary>
        /// The activation context being deactivated is not active for the current thread of execution.
        /// </summary>
        SxsInvalidDeactivation = 0x00003705,

        /// <summary>
        /// The activation context being deactivated has already been deactivated.
        /// </summary>
        SxsMultipleDeactivation = 0x00003706,

        /// <summary>
        /// The identity string is malformed. This may be due to a trailing comma, more than two unnamed attributes, missing attribute name or missing attribute value.
        /// </summary>
        SxsIdentityParseError = 0x0000370D,

        /// <summary>
        /// The component must be locked before making the request.
        /// </summary>
        SxsAssemblyNotLocked = 0x00003711,

        /// <summary>
        /// An advanced installer failed during setup or servicing.
        /// </summary>
        AdvancedInstallerFailed = 0x00003713,

        /// <summary>
        /// The character encoding in the XML declaration did not match the encoding used in the document.
        /// </summary>
        XmlEncodingMismatch = 0x00003714,

        /// <summary>
        /// The component identities are different.
        /// </summary>
        SxsIdentitiesDifferent = 0x00003716,

        /// <summary>
        /// The size of the manifest exceeds the maximum allowed.
        /// </summary>
        SxsManifestTooBig = 0x00003719,

        /// <summary>
        /// A generic command executable returned a result that indicates failure.
        /// </summary>
        GenericCommandFailed = 0x0000371D,

        /// <summary>
        /// A component is missing file verification information in its manifest.
        /// </summary>
        SxsFileHashMissing = 0x0000371E,

        /// <summary>
        /// The specified channel path is invalid.
        /// </summary>
        EvtInvalidChannelPath = 0x00003A98,

        /// <summary>
        /// The specified query is invalid.
        /// </summary>
        EvtInvalidQuery = 0x00003A99,

        /// <summary>
        /// The event data raised by the publisher is not compatible with the event template definition in the publisher's manifest
        /// </summary>
        EvtInvalidEventData = 0x00003A9D,

        /// <summary>
        /// The specified channel could not be found. Check channel configuration.
        /// </summary>
        EvtChannelNotFound = 0x00003A9F,

        /// <summary>
        /// The specified xml text was not well-formed. See Extended Error for more details.
        /// </summary>
        EvtMalformedXmlText = 0x00003AA0,

        /// <summary>
        /// Configuration error.
        /// </summary>
        EvtConfigurationError = 0x00003AA2,

        /// <summary>
        /// The query result is stale / invalid. This may be due to the log being cleared or rolling over after the query result was created. Users should handle this code by releasing the query result object and reissuing the query.
        /// </summary>
        EvtQueryResultStale = 0x00003AA3,

        /// <summary>
        /// Registered MSXML doesn't support validation.
        /// </summary>
        EvtNonValidatingMsxml = 0x00003AA5,

        /// <summary>
        /// An expression can only be followed by a change of scope operation if it itself evaluates to a node set and is not already part of some other change of scope operation.
        /// </summary>
        EvtFilterAlreadyscoped = 0x00003AA6,

        /// <summary>
        /// Can't perform a step operation from a term that does not represent an element set.
        /// </summary>
        EvtFilterNoteltset = 0x00003AA7,

        /// <summary>
        /// Left hand side arguments to binary operators must be either attributes, nodes or variables and right hand side arguments must be constants.
        /// </summary>
        EvtFilterInvarg = 0x00003AA8,

        /// <summary>
        /// A step operation must involve either a node test or, in the case of a predicate, an algebraic expression against which to test each node in the node set identified by the preceeding node set can be evaluated.
        /// </summary>
        EvtFilterInvtest = 0x00003AA9,

        /// <summary>
        /// This data type is currently unsupported.
        /// </summary>
        EvtFilterInvtype = 0x00003AAA,

        /// <summary>
        /// A syntax error occurred at position %1!d!
        /// </summary>
        EvtFilterParseerr = 0x00003AAB,

        /// <summary>
        /// This operator is unsupported by this implementation of the filter.
        /// </summary>
        EvtFilterUnsupportedop = 0x00003AAC,

        /// <summary>
        /// The xpath expression exceeded supported complexity. Please symplify it or split it into two or more simple expressions.
        /// </summary>
        EvtFilterTooComplex = 0x00003AB2,

        /// <summary>
        /// the message resource is present but the message is not found in the string/message table
        /// </summary>
        EvtMessageNotFound = 0x00003AB3,

        /// <summary>
        /// The message id for the desired message could not be found.
        /// </summary>
        EvtMessageIdNotFound = 0x00003AB4,

        /// <summary>
        /// The maximum number of replacements has been reached.
        /// </summary>
        EvtMaxInsertsReached = 0x00003AB7,

        /// <summary>
        /// The resource is too old to be compatible.
        /// </summary>
        EvtVersionTooOld = 0x00003ABA,

        /// <summary>
        /// The resource is too new to be compatible.
        /// </summary>
        EvtVersionTooNew = 0x00003ABB,

        /// <summary>
        /// The publisher has been disabled and its resource is not available. This usually occurs when the publisher is in the process of being uninstalled or upgraded.
        /// </summary>
        EvtPublisherDisabled = 0x00003ABD,

        /// <summary>
        /// Attempted to create a numeric type that is outside of its valid range.
        /// </summary>
        EvtFilterOutOfRange = 0x00003ABE,

        /// <summary>
        /// The log of the subscription is in disabled state, and can not be used to forward events to. The log must first be enabled before the subscription can be activated.
        /// </summary>
        EcLogDisabled = 0x00003AE9,

        /// <summary>
        /// When forwarding events from local machine to itself, the query of the subscription can't contain target log of the subscription.
        /// </summary>
        EcCircularForwarding = 0x00003AEA,

        /// <summary>
        /// The credential store that is used to save credentials is full.
        /// </summary>
        EcCredstoreFull = 0x00003AEB,

        /// <summary>
        /// The credential used by this subscription can't be found in credential store.
        /// </summary>
        EcCredNotFound = 0x00003AEC,

        /// <summary>
        /// No active channel is found for the query.
        /// </summary>
        EcNoActiveChannel = 0x00003AED,

        /// <summary>
        /// The resource loader failed to find MUI file.
        /// </summary>
        MuiFileNotFound = 0x00003AFC,

        /// <summary>
        /// The resource loader failed to load MUI file because the file fail to pass validation.
        /// </summary>
        MuiInvalidFile = 0x00003AFD,

        /// <summary>
        /// The RC Manifest is corrupted with garbage data or unsupported version or missing required item.
        /// </summary>
        MuiInvalidRcConfig = 0x00003AFE,

        /// <summary>
        /// The RC Manifest has invalid culture name.
        /// </summary>
        MuiInvalidLocaleName = 0x00003AFF,

        /// <summary>
        /// The resource loader cache doesn't have loaded MUI entry.
        /// </summary>
        MuiFileNotLoaded = 0x00003B01,

        /// <summary>
        /// User stopped resource enumeration.
        /// </summary>
        ResourceEnumUserStop = 0x00003B02,

        /// <summary>
        /// Invalid PRI config file.
        /// </summary>
        MrmInvalidPriconfig = 0x00003B07,

        /// <summary>
        /// Invalid file type.
        /// </summary>
        MrmInvalidFileType = 0x00003B08,

        /// <summary>
        /// Unknown qualifier.
        /// </summary>
        MrmUnknownQualifier = 0x00003B09,

        /// <summary>
        /// No Candidate found.
        /// </summary>
        MrmNoCandidate = 0x00003B0B,

        /// <summary>
        /// Duplicate Resource Map.
        /// </summary>
        MrmDuplicateMapName = 0x00003B0E,

        /// <summary>
        /// Duplicate Entry.
        /// </summary>
        MrmDuplicateEntry = 0x00003B0F,

        /// <summary>
        /// Filepath too long.
        /// </summary>
        MrmFilepathTooLong = 0x00003B11,

        /// <summary>
        /// Invalid PRI File.
        /// </summary>
        MrmInvalidPriFile = 0x00003B16,

        /// <summary>
        /// ResourceMap Not Found.
        /// </summary>
        MrmMapNotFound = 0x00003B1F,

        /// <summary>
        /// Automerge is enabled in the PRI file.
        /// </summary>
        MrmAutomergeEnabled = 0x00003B23,

        /// <summary>
        /// Too many resources defined for package.
        /// </summary>
        MrmTooManyResources = 0x00003B24,

        /// <summary>
        /// The monitor's VCP Version (0xDF) VCP code returned an invalid version value.
        /// </summary>
        McaInvalidVcpVersion = 0x00003B61,

        /// <summary>
        /// The MCCS version in a monitor's mccs_ver capability does not match the MCCS version the monitor reports when the VCP Version (0xDF) VCP code is used.
        /// </summary>
        McaMccsVersionMismatch = 0x00003B63,

        /// <summary>
        /// An internal Monitor Configuration API error occurred.
        /// </summary>
        McaInternalError = 0x00003B65,

        /// <summary>
        /// The requested system device cannot be identified due to multiple indistinguishable devices potentially matching the identification criteria.
        /// </summary>
        AmbiguousSystemDevice = 0x00003B92,

        /// <summary>
        /// The requested system device cannot be found.
        /// </summary>
        SystemDeviceNotFound = 0x00003BC3,

        /// <summary>
        /// Hash generation for the specified hash version and hash type is not enabled on the server.
        /// </summary>
        HashNotSupported = 0x00003BC4,

        /// <summary>
        /// The hash requested from the server is not available or no longer valid.
        /// </summary>
        HashNotPresent = 0x00003BC5,

        /// <summary>
        /// The requested operation is not suppported for the specified handle.
        /// </summary>
        GpioOperationDenied = 0x00003BDD,

        /// <summary>
        /// The requested run level switch cannot be completed successfully.
        /// </summary>
        CannotSwitchRunlevel = 0x00003C28,

        /// <summary>
        /// The service has an invalid run level setting. The run level for a service
        /// must not be higher than the run level of its dependent services.
        /// </summary>
        InvalidRunlevelSetting = 0x00003C29,

        /// <summary>
        /// The requested run level switch cannot be completed successfully since
        /// one or more services will not stop or restart within the specified timeout.
        /// </summary>
        RunlevelSwitchTimeout = 0x00003C2A,

        /// <summary>
        /// One or more services failed to start during the service startup phase of a run level switch.
        /// </summary>
        ServicesFailedAutostart = 0x00003C2D,

        /// <summary>
        /// The task stop request cannot be completed immediately since
        /// task needs more time to shutdown.
        /// </summary>
        ComTaskStopPending = 0x00003C8D,

        /// <summary>
        /// Package was not found.
        /// </summary>
        InstallPackageNotFound = 0x00003CF1,

        /// <summary>
        /// Package data is invalid.
        /// </summary>
        InstallInvalidPackage = 0x00003CF2,

        /// <summary>
        /// There is not enough disk space on your computer. Please free up some space and try again.
        /// </summary>
        InstallOutOfDiskSpace = 0x00003CF4,

        /// <summary>
        /// There was a problem downloading your product.
        /// </summary>
        InstallNetworkFailure = 0x00003CF5,

        /// <summary>
        /// User cancelled the install request.
        /// </summary>
        InstallCancel = 0x00003CF8,

        /// <summary>
        /// Install failed. Please contact your software vendor.
        /// </summary>
        InstallFailed = 0x00003CF9,

        /// <summary>
        /// Removal failed. Please contact your software vendor.
        /// </summary>
        RemoveFailed = 0x00003CFA,

        /// <summary>
        /// The provided package is already installed, and reinstallation of the package was blocked. Check the AppXDeployment-Server event log for details.
        /// </summary>
        PackageAlreadyExists = 0x00003CFB,

        /// <summary>
        /// The application cannot be started. Try reinstalling the application to fix the problem.
        /// </summary>
        NeedsRemediation = 0x00003CFC,

        /// <summary>
        /// To install this application you need either a Windows developer license or a sideloading-enabled system.
        /// </summary>
        InstallPolicyFailure = 0x00003CFF,

        /// <summary>
        /// The application cannot be started because it is currently updating.
        /// </summary>
        PackageUpdating = 0x00003D00,

        /// <summary>
        /// The package could not be installed because resources it modifies are currently in use.
        /// </summary>
        PackagesInUse = 0x00003D02,

        /// <summary>
        /// The package could not be recovered because necessary data for recovery have been corrupted.
        /// </summary>
        RecoveryFileCorrupt = 0x00003D03,

        /// <summary>
        /// The signature is invalid. To register in developer mode, AppxSignature.p7x and AppxBlockMap.xml must be valid or should not be present.
        /// </summary>
        InvalidStagedSignature = 0x00003D04,

        /// <summary>
        /// The package could not be installed because a higher version of this package is already installed.
        /// </summary>
        InstallPackageDowngrade = 0x00003D06,

        /// <summary>
        /// An error in a system binary was detected. Try refreshing the PC to fix the problem.
        /// </summary>
        SystemNeedsRemediation = 0x00003D07,

        /// <summary>
        /// The operation could not be resumed because necessary data for recovery have been corrupted.
        /// </summary>
        ResiliencyFileCorrupt = 0x00003D09,

        /// <summary>
        /// The process has no package identity.
        /// </summary>
        AppmodelNoPackage = 0x00003D54,

        /// <summary>
        /// The process has no application identity.
        /// </summary>
        AppmodelNoApplication = 0x00003D57,

        /// <summary>
        /// Loading the state store failed.
        /// </summary>
        StateLoadStoreFailed = 0x00003DB8,

        /// <summary>
        /// Retrieving the state version for the application failed.
        /// </summary>
        StateGetVersionFailed = 0x00003DB9,

        /// <summary>
        /// Setting the state version for the application failed.
        /// </summary>
        StateSetVersionFailed = 0x00003DBA,

        /// <summary>
        /// State Manager failed to read the setting.
        /// </summary>
        StateReadSettingFailed = 0x00003DBF,

        /// <summary>
        /// This API cannot be used in the context of the caller's application type.
        /// </summary>
        ApiUnavailable = 0x00003DE1,

        /// <summary>
        /// This PC does not have a valid license for the application or product.
        /// </summary>
        StoreUnlicensed = 0x00003DF5,

        /// <summary>
        /// The authenticated user does not have a valid license for the application or product.
        /// </summary>
        StoreUnlicensedUser = 0x00003DF6,

        /// <summary>
        /// The license has been revoked for this user.
        /// </summary>
        StoreLicenseRevoked = 0x00003DF8,
    }
}

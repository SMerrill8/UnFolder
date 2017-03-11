# Unfolder Wiki

**Target Platform:** Windows

**Author:** Shaun Merrill, Seattle-area programmer

**Dev Environment:** Visual Studio 2015

---

## Problem:
I have imported pictures from many cameras over the years into an external drive.  The pictures are disorganized into multitudinous folders and sub-folders.  In some places, there is one folder per date!  How annoying.

## Solution:

### Use Case 1: Unload a single folder

1. Right-mouse Folder A, which contains media files.
2. Choose _**UnFolder**_ from the shortcut menu.

    **Expected Results:**

    1. All files and folders within Folder A will be moved to the parent folder (the one which contains Folder A).
    2. Folder A will be deleted if it is empty.

### Use Case 2: Unload a folder tree

1. Right-mouse a folder containing media files.
2. Choose _**UnFolder All**_ from the shortcut menu.

    **Expected Results:**

    1. All files within Folder A, along with all of the content of folders recursively found within Folder A will be moved to the parent folder which contains Folder A.  This action should start with the innermost folders which do not contain any folders.  It should unload the folder into its parent, then delete it and proceed on to the next folder.

    2. The entire Folder A tree will end up deleted because it will be empty.

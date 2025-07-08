using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace Powershell.ShowBrowseDialog
{
    public static class DialogHelper
    {
        /// <summary>
        /// Shows a highly configurable FolderBrowserDialog (all parameters exposed).
        /// Falls back to user profile folder if the requested root/initial directory does not exist.
        /// Optionally sets UseDescriptionForTitle (only if supported by your .NET runtime).
        /// </summary>
        /// <param name="description">The title or description for the dialog window.</param>
        /// <param name="rootFolder">Root folder to start browsing from (e.g., "Desktop", "MyComputer", "MyDocuments").</param>
        /// <param name="selectedPath">Initial selected folder path. If invalid, defaults to user profile.</param>
        /// <param name="showNewFolderButton">Show the 'New Folder' button. Default: true.</param>
        /// <param name="useDescriptionForTitle">Use the description as window title (if supported by .NET 4.5+).</param>
        /// <returns>The selected folder path, or null if canceled.</returns>
        public static string ShowBrowseDialog(
            string description = null,
            string rootFolder = "Desktop",
            string selectedPath = null,
            bool showNewFolderButton = true,
            bool useDescriptionForTitle = false
        )
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new PlatformNotSupportedException(
                    "ShowBrowseDialog can only be used on Windows. " +
                    "This feature is not supported on Linux or macOS. " +
                    "Please run this command on a Windows machine."
                );

            string chosenPath = null;
            Thread t = new Thread(() =>
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    // Set the dialog description (if provided)
                    if (!string.IsNullOrWhiteSpace(description))
                        dialog.Description = description;

                    // Set the root folder (fallback to Desktop if unrecognized)
                    if (!Enum.TryParse(rootFolder, true, out Environment.SpecialFolder rootSpecialFolder))
                        rootSpecialFolder = Environment.SpecialFolder.Desktop;
                    dialog.RootFolder = rootSpecialFolder;

                    // Determine fallback path (user profile, MyDocuments, or C:\)
                    string fallbackPath;
                    try
                    {
                        fallbackPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        if (string.IsNullOrWhiteSpace(fallbackPath) || !Directory.Exists(fallbackPath))
                            fallbackPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    }
                    catch
                    {
                        fallbackPath = "C:\\";
                    }

                    // Set the selected path (if valid) or fallback
                    if (!string.IsNullOrWhiteSpace(selectedPath) && Directory.Exists(selectedPath))
                        dialog.SelectedPath = selectedPath;
                    else
                    {
                        string rootFolderPath = Environment.GetFolderPath(rootSpecialFolder);
                        if (!string.IsNullOrWhiteSpace(rootFolderPath) && Directory.Exists(rootFolderPath))
                            dialog.SelectedPath = rootFolderPath;
                        else
                            dialog.SelectedPath = fallbackPath;
                    }

                    dialog.ShowNewFolderButton = showNewFolderButton;

                    // Set UseDescriptionForTitle using reflection, only if available
                    if (useDescriptionForTitle)
                    {
                        var prop = dialog.GetType().GetProperty("UseDescriptionForTitle");
                        if (prop != null && prop.CanWrite)
                        {
                            prop.SetValue(dialog, true, null);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "The property 'UseDescriptionForTitle' is not available in this version of .NET. " +
                                "Please upgrade to .NET 4.5 or higher to use this feature."
                            );
                        }
                    }

                    // Show the dialog and get the chosen path if user selects one
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK || result == DialogResult.Yes)
                        chosenPath = dialog.SelectedPath;
                }
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return chosenPath;
        }
    }
}

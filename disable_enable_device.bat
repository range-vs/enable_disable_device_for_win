start devmgmt.msc
enable_disable_device_for_win.exe {GUID} 0
enable_disable_device_for_win.exe {GUID} 1
timeout 3
Taskkill /IM mmc.exe /F
rem pause
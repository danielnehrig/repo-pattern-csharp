# Project Information
PKG = -pkg:dotnet
COMP = mcs
SRCPATH = ./src/server/
COMPILEPATH = ./dist/
FILENAME = repo.exe

# Base Files
MAINSRC = $(SRCPATH)Controller/IOController.cs \
					$(SRCPATH)Administration/StudentAdmin.cs \
					$(SRCPATH)Administration/TeacherAdmin.cs \
					$(SRCPATH)Administration/Manager.cs \
					$(SRCPATH)Administration/RepoAdmin.cs \
					$(SRCPATH)Types/GlobalInterface.cs \
					$(SRCPATH)Types/Student.cs \
					$(SRCPATH)Types/Teacher.cs \
					$(SRCPATH)Types/TypeRepo.cs \
					$(SRCPATH)Helper/ReadConfig.cs \
					$(SRCPATH)Helper/Utils.cs


# Build Console GTK and WPF
CONSOLE = $(MAINSRC) $(SRCPATH)ConsoleApp/ConsoleApp.cs $(SRCPATH)Program_Console.cs

BuildConsole:
	$(COMP) $(CONSOLE) $(PKG) -out:$(FILENAME)
	mv $(FILENAME) $(COMPILEPATH)$(FILENAME)
	cp $(SRCPATH)config.cfg $(COMPILEPATH)config.cfg

Clean:
	rm $(COMPILEPATH)*.exe
	rm $(COMPILEPATH)config.cfg

Start:
	cd $(COMPILEPATH); \
	mono ./$(FILENAME)

param (
    [string]$application = $null
)

# Function Build-CoverageSnapshot {
# 	dotcover dotnet .\code-coverage\Impulse.Common.Tests.xml
# }



switch ($application)
{
	########################################
	# TODO: Generic
	########################################

	# "cover" { 
	# 	Write-Host "Code coverage using dotCover"

	# 	# This is for .net Framework
	# 	#dotcover cover .\code-coverage\Impulse.Common.Tests.xml

	# 	# This is for .NET Core
	# 	Build-CoverageSnapshot

	# }

	# "merge" {
	# 	dotcover merge .\code-coverage\_merge.xml
	# }

	# "report" {
	# 	dotcover report .\code-coverage\_report.xml
	# }

	# "all" {
	# 	Build-CoverageSnapshot
	# 	dotcover merge .\code-coverage\_merge.xml
	# 	dotcover report .\code-coverage\_report.xml
	# }


	"hello" {
		# Working
		$inputFileName = "helloWorld.gv"
		$outputFileName = "helloWorld.png"
		# Start-Process -FilePath "D:\Apps\Graphviz\bin\dot.exe" -ArgumentList "-Tpng helloWorld.gv" -RedirectStandardOutput "w1.png" -NoNewWindow
		Start-Process -FilePath "dot.exe" -ArgumentList "-Tpng $inputFileName" -RedirectStandardOutput $outputFileName -NoNewWindow
		Write-Host "PNG file [$outputFileName] generated from [$inputFileName]"

		# Not working
		# "D:\Apps\Graphviz\bin\dot.exe"
		# dot -Tpng helloWorld.gv > helloWorld.png
		# Invoke-Expression "dot -Tpng helloWorld.gv > helloWorld.png"
		# Invoke-Expression "dot -Tpng helloWorld.gv | Out-File -Encoding OEM helloWorld.png"
		# dot -Tpng helloWorld.gv | Out-File -Encoding OEM test2.png
		#& dot -Tpng helloWorld.gv | Out-File -Encoding OEM helloWorld1.png
		# dot -Tpng helloWorld.gv | Out-File  test2.png
		# dot -Tpng helloWorld.gv | Get-Content -Raw
		# Set-Content -Path test3.png -AsByteStream
		# dot -Tpng helloWorld.gv *>&1 xxx.png
		# dot -Tpng helloWorld.gv > Get-Content -Encoding OEM

		#ZX:The problem is is PowerShell's redirection operators (>)
		#	It corrupts the output of executables

	}
    default {
		if (Test-Path $application)
		{
			# If is a graphviz file
			$fileName = [System.IO.Path]::GetFileNameWithoutExtension($application)
			$outputFileName = "$fileName.pdf"
			#Start-Process -FilePath "dot.exe" -ArgumentList "-Tpng $application" -RedirectStandardOutput $outputFileName -NoNewWindow
			Start-Process -FilePath "fdp.exe" -ArgumentList "-Tpdf $application" -RedirectStandardOutput $outputFileName -NoNewWindow
			Write-Host "PNG file [$outputFileName] generated from [$application]"
			return

# dot − filter for drawing directed graphs
# dot draws directed graphs. It works well on directed acyclic graphs and other graphs that can be drawn as hierarchies or have a natural ‘‘flow.’’

# neato draws undirected graphs using a ‘‘spring’’ model and reducing the related energy
# neato − filter for drawing undirected graphs

# fdp − filter for drawing undirected graphs
# sfdp − filter for drawing large undirected graphs

# patchwork − filter for squarified tree maps
# osage − filter for array-based layouts

# twopi − filter for radial layouts of graphs
# circo − filter for circular layout of graphs

		}

		Write-Host "Unsupported option $application $Args"
	}
}

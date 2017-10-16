# nClam-Test
Project to test the capabilities of the nClam API

## Setup Instructions

1. Download the ClamAV srever from [here](http://oss.netfarm.it/clamav/files/clamav-amd64-0.99.2.7z)
2. Extract the binaries to `C:\clamav`
3. Create an empty directory called `DB` in the `C:\clamav` directory
4. From an administrator command prompt `cd` into `C:\clamav` directory and run the `freshclam` command. This will download the most up to date virus databases into the `DB` directory
5. Start the ClamAV Service by running `clamd --install`
6. Start the updater srevice by running `freshclam --install`
7. Set the ClamAV Services to run automatically at startup as shown in the image below

![Image](https://d33wubrfki0l68.cloudfront.net/795f3f6e31654b9116c4717490102a1c9883cdbe/7b7cc/images/2011/05/image4.png)

8. The ClamAV Sever should now be started at `localhost:3310`. You can test this by navigating to it and the text `UNKNOWN COMMAND` should appear in the browser.

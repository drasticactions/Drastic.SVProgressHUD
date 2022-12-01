XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
ROOT=$(PWD)
PROJECT_ROOT=$(ROOT)/../external/SVProgressHUD
PROJECT=$(PROJECT_ROOT)/SVProgressHUD.xcodeproj
BUILD_ROOT=$(PROJECT_ROOT)/build
TARGET_IOS=SVProgressHUD-Framework
TARGET_TVOS=SVProgressHUD-Framework
PROJECTNAME=SVProgressHUD
OUTPUT=$(ROOT)/Build
FRAMEWORK_PATH=Products/Library/Frameworks/SVProgressHUD.framework
FRAMEWORKS=$(ROOT)/Frameworks
FRAMEWORKS_IOS=$(ROOT)/Frameworks/ios
FRAMEWORKS_TVOS=$(ROOT)/Frameworks/tvos
IOS_SDK=iphoneos16.1
BINDING_OUTPUT=$(ROOT)/../bindings

all: iossimulator iosdevice maccatalyst tvossimulator tvosdevice xcframework dotnet

build: iossimulator iosdevice maccatalyst tvossimulator tvosdevice xcframework dotnet

pack: build nuget

iossimulator:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -scheme $(TARGET_IOS) -destination="generic/platform=iOS Simulator" -archivePath $(BUILD_ROOT)/simulator.xcarchive -sdk iphonesimulator SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

iosdevice:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -scheme $(TARGET_IOS) -destination="generic/platform=iOS" -archivePath $(BUILD_ROOT)/iOS.xcarchive -sdk iphoneos SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

maccatalyst:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -scheme $(TARGET_IOS) -destination="generic/platform=macOS,variant=Mac Catalyst" -archivePath $(BUILD_ROOT)/catalyst.xcarchive SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

tvossimulator:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -scheme $(TARGET_TVOS) -archivePath $(BUILD_ROOT)/tvsimulator.xcarchive -sdk appletvsimulator SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

tvosdevice:
	$(XBUILD) archive ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -scheme $(TARGET_TVOS) -archivePath $(BUILD_ROOT)/tvos.xcarchive -sdk appletvos SKIP_INSTALL=NO BUILD_LIBRARY_FOR_DISTRIBUTION=YES

xcframework:
	rm -rf $(BUILD_ROOT)/SVProgressHUD.xcframework
	$(XBUILD) -create-xcframework -framework $(BUILD_ROOT)/simulator.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/tvsimulator.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/tvos.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/iOS.xcarchive/$(FRAMEWORK_PATH) -framework $(BUILD_ROOT)/catalyst.xcarchive/$(FRAMEWORK_PATH) -output $(BUILD_ROOT)/SVProgressHUD.xcframework
	rm -rf $(FRAMEWORKS)
	mkdir -p $(FRAMEWORKS)
	mv $(BUILD_ROOT)/SVProgressHUD.xcframework $(FRAMEWORKS)/SVProgressHUD.xcframework

dotnet:
	dotnet build

nuget:
	dotnet pack --configuration Release

sharpie:
	sharpie bind --sdk=$(IOS_SDK) --output="$(BINDING_OUTPUT)" --namespace="Drastic.SVProgressHUD" --scope="$(FRAMEWORKS)/SVProgressHUD.xcframework/ios-arm64/SVProgressHUD.framework/Headers" $(FRAMEWORKS)/SVProgressHUD.xcframework/ios-arm64/SVProgressHUD.framework/Headers/*.h
pkgname = heroclimb
pkgver = 0.1.0
arch = x86_64

windows_pkg = $(pkgname)-windows-$(pkgver)-$(arch)
linux_pkg = $(pkgname)-linux-$(pkgver)-$(arch)
android_pkg = $(pkgname)-android-$(pkgver)-any.apk

build:
	echo "run export in godot"

clean:
	rm -rf Linux/*
	rm -rf Windows/*
	rm -rf Android/*
	rm -rf Pkg/*

package_windows:
	mkdir Pkg/$(windows_pkg)
	cp ../../README.md Pkg/$(windows_pkg)
	cp ../../Manual.md Pkg/$(windows_pkg)
	cp -r Windows/* Pkg/$(windows_pkg)
	cd Pkg; zip -r $(windows_pkg).zip $(windows_pkg)

package_linux:
	mkdir Pkg/$(linux_pkg)
	cp ../../README.md Pkg/$(linux_pkg)
	cp ../../Manual.md Pkg/$(linux_pkg)
	cp -r Linux/* Pkg/$(linux_pkg)
	cd Pkg; zip -r $(linux_pkg).zip $(linux_pkg)

package_android:
	cp Android/heroclimb.apk Pkg/$(android_pkg)

package: package_windows package_linux package_android


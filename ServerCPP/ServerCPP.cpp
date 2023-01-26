#include <iostream>
#include <Windows.h>
#include <string>
#include <vector>
#define SIZE (DWORD)1096

HANDLE hMapFile;
LPVOID lpMapAddress;

std::vector<byte> Read()
{
    int size = *(int*)lpMapAddress;
    std::vector<byte> buffer(size);
    memcpy(&buffer[0], (byte*)lpMapAddress + 4, size);
    return buffer;
}

void Write(std::vector<byte> bytes)
{
    int size = bytes.size();
    memcpy(lpMapAddress, &size, 4);
    memcpy((byte*)lpMapAddress + 4, &bytes[0], size);
}

int main()
{
    hMapFile = CreateFileMapping(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, SIZE, L"vN$8n432");
    if (hMapFile == NULL) {
        std::cout << "Could not create file mapping object" << std::endl;
        return 1;
    }
    lpMapAddress = MapViewOfFile(hMapFile, FILE_MAP_ALL_ACCESS, 0, 0, SIZE);
    if (lpMapAddress == NULL) {
        std::cout << "Could not map view of file" << std::endl;
        CloseHandle(hMapFile);
        return 1;
    }

    std::string str = "Hello Maps!! (From C++)";
    std::vector<byte> bytes(str.begin(), str.end());
    Write(bytes);
    std::cin.get();

    UnmapViewOfFile(lpMapAddress);
    CloseHandle(hMapFile);
    return 0;
}
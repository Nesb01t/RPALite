import os


def imageList(itemtype: str):
    imagelist = []
    folder = '../datacollect/imagehitbox/' + itemtype
    for filename in os.listdir(folder):
        if filename.endswith('.jpg') or filename.endswith('png'):
            path = os.path.join(folder, filename)
            imagelist.append(path)
    return imagelist

import http from "../http-common";

class UploadFilesService {
  upload(file, onUploadProgress) {
    let formData = new FormData();

    formData.append("file", file);

    return http.post("/fileupload/SaveFileUsingBuffered", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
      onUploadProgress,
    });
  }

  getFiles() {
    return http.get("/fileupload");
  }
  getFileById(fileitemid) {
    return http.get("/fileupload/" + fileitemid);
  }
}

export default new UploadFilesService();

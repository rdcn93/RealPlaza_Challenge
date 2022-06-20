import http from "../http-common";
import ITutorialData from "../types/product.type"

class TutorialDataService {
  getAll() {
    return http.get<Array<ITutorialData>>("/product");
  }

  get(id: string) {
    return http.get<ITutorialData>(`/product/${id}`);
  }

  create(data: ITutorialData) {
    return http.post<ITutorialData>("/product", data);
  }

  update(data: ITutorialData, id: any) {
    return http.put<any>(`/product/${id}`, data);
  }

  delete(id: any) {
    return http.delete<any>(`/product/${id}`);
  }

//   deleteAll() {
//     return http.delete<any>(`/product`);
//   }

  findByName(name: string) {
    return http.get<Array<ITutorialData>>(`/product?title=${name}`);
  }
}

export default new TutorialDataService();
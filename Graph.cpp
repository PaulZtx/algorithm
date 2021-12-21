#include <iostream>
#include <vector>

using namespace std;

vector<vector<int>> graph;
vector<int> used;
vector<int> path;


void dfs(int v, int start){
    if(used[v]){
        if(v == start) {
            for (int i = 0; i < path.size(); ++i)
                cout << path[i] + 1 << " "; // тут единицу добавил для последнего теста с красным графом
            cout << v + 1 << endl; //и тут 
        }
        return;
    }

    used[v] = 1;

    path.push_back(v);
    for(int i = 0; i < graph[v].size(); ++i)
        if(graph[v][i] == 1)
            dfs(i, start);

    used[v] = 0;

    path.pop_back();
}

int main() {
//    graph.push_back({ 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 }); //0
//    graph.push_back({ 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 }); //1
//    graph.push_back({ 0, 0, 0, 1, 0, 1, 0, 0, 1, 0 }); //2
//    graph.push_back({ 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 }); //3
//    graph.push_back({ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }); //4
//    graph.push_back({ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }); //5
//    graph.push_back({ 0, 0, 0, 1, 0, 1, 0, 1, 0, 0 }); //6
//    graph.push_back({ 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }); //7
//    graph.push_back({ 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 }); //8
//    graph.push_back({ 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }); //9
        graph.push_back({ 0, 1, 1, 0, 0}); //1
        graph.push_back({ 0, 0, 1, 0, 1}); //2
        graph.push_back({ 0, 0, 0, 1, 0}); //3
        graph.push_back({ 0, 0, 0, 0, 1}); //4
        graph.push_back({ 1, 0, 0, 0, 0}); //5




    for(int i = 0; i < graph[0].size(); i++) {
        used.resize(graph[0].size(), 0);
        dfs(i, i);
        //path.clear();
    }
    return 0;
}

